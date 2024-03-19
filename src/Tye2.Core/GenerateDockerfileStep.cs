

using System.IO;
using System.Threading.Tasks;

namespace Tye2.Core
{
    internal sealed class GenerateDockerfileStep : ApplicationExecutor.ServiceStep
    {
        public override string DisplayText => "Generating Dockerfile...";

        public bool Force { get; set; }

        public override async Task ExecuteAsync(OutputContext output, ApplicationBuilder application, ServiceBuilder service)
        {
            if (SkipWithoutDotnetProject(output, service, out var project))
            {
                return;
            }

            if (SkipWithoutContainerInfo(output, service, out var container))
            {
                return;
            }

            if (container.UseMultiphaseDockerfile == false)
            {
                throw new CommandException("Generated Dockerfile workflow does not support single-phase Dockerfiles.");
            }

            container.UseMultiphaseDockerfile ??= true;

            var dockerFilePath = Path.Combine(project.ProjectFile.DirectoryName!, "Dockerfile");
            if (File.Exists(dockerFilePath) && !Force)
            {
                throw new CommandException("'Dockerfile' already exists for project. use '--force' to overwrite.");
            }

            File.Delete(dockerFilePath);

            await DockerfileGenerator.WriteDockerfileAsync(output, application, project, container, dockerFilePath);
            output.WriteInfoLine($"Generated Dockerfile at '{dockerFilePath}'.");
        }
    }
}
