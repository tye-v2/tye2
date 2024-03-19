﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Semver;
using Tye2.Core.MsBuild;

namespace Tye2.Core
{
    public static class ProjectReader
    {

        public static IEnumerable<FileInfo> EnumerateProjects(FileInfo solutionFile)
        {
            return EnumerateProjectsCore(solutionFile);
        }

        // Do not load MSBuild types before using EnsureMSBuildRegistered.
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static IEnumerable<FileInfo> EnumerateProjectsCore(FileInfo solutionFile)
        {
            var solution = SolutionFile.Parse(solutionFile.FullName);
            foreach (var project in solution.ProjectsInOrder)
            {
                if (project.ProjectType != SolutionProjectType.KnownToBeMSBuildFormat)
                {
                    continue;
                }

                var extension = Path.GetExtension(project.AbsolutePath).ToLower();
                switch (extension)
                {
                    case ".csproj":
                    case ".fsproj":
                        break;
                    default:
                        continue;
                }

                yield return new FileInfo(project.AbsolutePath.Replace('\\', '/'));
            }
        }

        public static void ReadProjectDetails(OutputContext output, DotnetProjectServiceBuilder project, string metadataFile)
        {
            if (output is null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            if (project is null)
            {
                throw new ArgumentNullException(nameof(project));
            }

            if (metadataFile is null)
            {
                throw new ArgumentNullException(nameof(metadataFile));
            }

            EvaluateProject(output, project, metadataFile);

            if (!SemVersion.TryParse(project.Version, out var version))
            {
                output.WriteInfoLine($"No version or invalid version '{project.Version}' found, using default.");
                version = new SemVersion(0, 1, 0);
                project.Version = version.ToString();
            }
        }

        public static void ReadAzureFunctionProjectDetails(OutputContext output, AzureFunctionServiceBuilder project, string metadataFile)
        {
            if (output is null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            if (project is null)
            {
                throw new ArgumentNullException(nameof(project));
            }

            if (metadataFile is null)
            {
                throw new ArgumentNullException(nameof(metadataFile));
            }

            EvaluateAzureFunctionProject(output, project, metadataFile);
        }

        // Do not load MSBuild types before using EnsureMSBuildRegistered.
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void EvaluateProject(OutputContext output, DotnetProjectServiceBuilder project, string metadataFile)
        {
            var sw = Stopwatch.StartNew();

            var metadata = new Dictionary<string, string>();
            var metadataKVPs = File.ReadLines(metadataFile).Select(l => l.Split(new[] { ':' }, 2));

            foreach (var metadataKVP in metadataKVPs)
            {
                if (!string.IsNullOrEmpty(metadataKVP[1]))
                {
                    metadata.Add(metadataKVP[0], metadataKVP[1].Trim());
                }
            }

            // Reading a few different version properties to be more resilient.
            var version = GetMetadataValueOrNull("AssemblyInformationalVersion") ??
                 GetMetadataValueOrNull("InformationalVersion") ??
                 GetMetadataValueOrEmpty("Version");
            project.Version = version;
            output.WriteDebugLine($"Found application version: {version}");

            project.TargetFrameworks = GetMetadataValueOrNull("TargetFrameworks")?.Split(';', StringSplitOptions.RemoveEmptyEntries) ?? Array.Empty<string>();

            // Figure out if functions app.
            // If so, run app with function host.
            project.RunCommand = GetMetadataValueOrEmpty("RunCommand");
            project.RunArguments = GetMetadataValueOrEmpty("RunArguments");
            project.TargetPath = GetMetadataValueOrEmpty("TargetPath");
            project.PublishDir = GetMetadataValueOrEmpty("PublishDir");
            project.AssemblyName = GetMetadataValueOrEmpty("AssemblyName");
            project.IntermediateOutputPath = GetMetadataValueOrEmpty("IntermediateOutputPath");

            output.WriteDebugLine($"RunCommand={project.RunCommand}");
            output.WriteDebugLine($"RunArguments={project.RunArguments}");
            output.WriteDebugLine($"TargetPath={project.TargetPath}");
            output.WriteDebugLine($"PublishDir={project.PublishDir}");
            output.WriteDebugLine($"AssemblyName={project.AssemblyName}");
            output.WriteDebugLine($"IntermediateOutputPath={project.IntermediateOutputPath}");

            // Normalize directories to their absolute paths
            project.IntermediateOutputPath = Path.Combine(project.ProjectFile.DirectoryName!, NormalizePath(project.IntermediateOutputPath));
            project.TargetPath = Path.Combine(project.ProjectFile.DirectoryName!, NormalizePath(project.TargetPath));
            project.PublishDir = Path.Combine(project.ProjectFile.DirectoryName!, NormalizePath(project.PublishDir));

            var targetFramework = GetMetadataValueOrEmpty("TargetFramework");
            project.TargetFramework = targetFramework;
            output.WriteDebugLine($"Found target framework: {targetFramework}");

            // TODO: Parse the name and version manually out of the TargetFramework field if it's non-null
            project.TargetFrameworkName = GetMetadataValueOrNull("_ShortFrameworkIdentifier") ?? project.TargetFramework.TrimEnd(".0123456789".ToCharArray());
            project.TargetFrameworkVersion = GetMetadataValueOrNull("_ShortFrameworkVersion") ?? GetMetadataValueOrEmpty("_TargetFrameworkVersionWithoutV");
            output.WriteDebugLine($"Parsed target framework name: {project.TargetFrameworkName}");
            output.WriteDebugLine($"Parsed target framework version: {project.TargetFrameworkVersion}");

            var sharedFrameworks = GetMetadataValueOrNull("FrameworkReference")?.Split(';') ?? Enumerable.Empty<string>();
            project.Frameworks.AddRange(sharedFrameworks.Select(s => new Framework(s)));
            output.WriteDebugLine($"Found shared frameworks: {string.Join(", ", sharedFrameworks)}");

            // determine container base image
            if (project.ContainerInfo != null)
            {
                project.ContainerInfo.BaseImageName = GetMetadataValueOrEmpty("ContainerBaseImage");
                project.ContainerInfo.BaseImageTag = GetMetadataValueOrEmpty("ContainerBaseTag");
            }

            project.IsAspNet = project.Frameworks.Any(f => f.Name == "Microsoft.AspNetCore.App") ||
                               GetMetadataValueOrEmpty("MicrosoftNETPlatformLibrary") == "Microsoft.AspNetCore.App" ||
                               MetadataIsTrue("_AspNetCoreAppSharedFxIsEnabled") ||
                               MetadataIsTrue("UsingMicrosoftNETSdkWeb");

            output.WriteDebugLine($"IsAspNet={project.IsAspNet}");

            output.WriteDebugLine($"Evaluation Took: {sw.Elapsed.TotalMilliseconds}ms");

            string? GetMetadataValueOrNull(string key) => metadata!.TryGetValue(key, out var value) ? value : null;
            string GetMetadataValueOrEmpty(string key) => metadata!.TryGetValue(key, out var value) ? value : string.Empty;
            bool MetadataIsTrue(string key) => metadata!.TryGetValue(key, out var value) && bool.Parse(value);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void EvaluateAzureFunctionProject(OutputContext output, AzureFunctionServiceBuilder project, string metadataFile)
        {
            var sw = Stopwatch.StartNew();

            var metadata = new Dictionary<string, string>();
            var metadataKVPs = File.ReadLines(metadataFile).Select(l => l.Split(new[] { ':' }, 2));

            foreach (var metadataKVP in metadataKVPs)
            {
                if (!string.IsNullOrEmpty(metadataKVP[1]))
                {
                    metadata.Add(metadataKVP[0], metadataKVP[1].Trim());
                }
            }

            project.AzureFunctionsVersion = GetMetadataValueOrNull("AzureFunctionsVersion");

            output.WriteDebugLine($"AzureFunctionsVersion={project.AzureFunctionsVersion}");

            output.WriteDebugLine($"Evaluation Took: {sw.Elapsed.TotalMilliseconds}ms");

            string? GetMetadataValueOrNull(string key) => metadata!.TryGetValue(key, out var value) ? value : null;
        }

        private static string NormalizePath(string path)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return path.Replace('/', '\\');
            }
            return path.Replace('\\', '/');
        }
    }
}
