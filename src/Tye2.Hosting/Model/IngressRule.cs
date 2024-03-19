

namespace Tye2.Hosting.Model
{
    public class IngressRule
    {
        public IngressRule(string? host, string? path, string service, bool preservePath)
        {
            Host = host;
            Path = path;
            PreservePath = preservePath;
            Service = service;
        }

        public string? Host { get; }
        public string? Path { get; }
        public bool PreservePath { get; }
        public string Service { get; }
    }
}
