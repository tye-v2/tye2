

namespace Tye2.Core
{
    public class AzureFunctionServiceBuilder : LaunchedServiceBuilder
    {
        public AzureFunctionServiceBuilder(string name, string path, ServiceSource source)
            : base(name, source)
        {
            FunctionPath = path;
        }

        public string? Args { get; set; }
        public string FunctionPath { get; }
        public string? FuncExecutablePath { get; set; }
        public string? ProjectFile { get; set; }
        public string? AzureFunctionsVersion { get; set; }
    }
}
