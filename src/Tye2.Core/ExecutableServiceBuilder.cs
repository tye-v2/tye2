

namespace Tye2.Core
{
    public sealed class ExecutableServiceBuilder : LaunchedServiceBuilder
    {
        public ExecutableServiceBuilder(string name, string executable, ServiceSource source)
            : base(name, source)
        {
            Executable = executable;
        }

        public string Executable { get; }

        public string? WorkingDirectory { get; set; }

        public string? Args { get; set; }

        public ProbeBuilder? Liveness { get; set; }

        public ProbeBuilder? Readiness { get; set; }
    }
}
