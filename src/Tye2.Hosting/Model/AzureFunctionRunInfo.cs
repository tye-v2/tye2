// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Tye2.Core;

namespace Tye2.Hosting.Model
{
    public class AzureFunctionRunInfo : RunInfo
    {
        public AzureFunctionRunInfo(AzureFunctionServiceBuilder function)
        {
            Args = function.Args;
            AzureFunctionsVersion = function.AzureFunctionsVersion;
            FunctionPath = function.FunctionPath;
            FuncExecutablePath = function.FuncExecutablePath;
            ProjectFile = function.ProjectFile;
        }

        public string? Args { get; }
        public string? AzureFunctionsVersion { get; }
        public string FunctionPath { get; }
        public string? FuncExecutablePath { get; set; }
        public string? ProjectFile { get; set; }
    }
}
