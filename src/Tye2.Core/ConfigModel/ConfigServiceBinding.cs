

using System.Collections.Generic;

namespace Tye2.Core.ConfigModel
{
    public class ConfigServiceBinding
    {
        public string? Name { get; set; }
        public string? ConnectionString { get; set; }
        public int? Port { get; set; }
        public int? ContainerPort { get; set; }
        public string? Host { get; set; }
        public string? Protocol { get; set; }
        public List<string> Routes { get; set; } = new List<string>();
    }
}
