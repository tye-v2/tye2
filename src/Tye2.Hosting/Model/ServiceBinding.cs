

using System.Collections.Generic;

namespace Tye2.Hosting.Model
{
    public class ServiceBinding
    {
        public string? Name { get; set; }
        public string? ConnectionString { get; set; }
        public int? Port { get; set; }
        public int? ContainerPort { get; set; }
        public string? Host { get; set; }
        public string? IPAddress { get; set; }
        public string? Protocol { get; set; }
        public List<int> ReplicaPorts { get; } = new List<int>();
        public List<string> Routes { get; } = new List<string>();
    }
}
