

namespace Tye2.Hosting.Model
{
    public class EnvironmentVariableSource
    {
        public EnvironmentVariableSource(string service, string? binding)
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
