

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
