

namespace Tye2.Core
{
    public sealed class EnvironmentVariableSourceBuilder
    {
        public EnvironmentVariableSourceBuilder(string service, string? binding)
        {
            Service = service;
            Binding = binding;
        }

        public string Service { get; }
        public string? Binding { get; }

        public SourceKind Kind { get; set; }

        public enum SourceKind
        {
            Url,
            Port,
            Host,
            ConnectionString,
        }
    }
}
