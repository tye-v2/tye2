

namespace Tye2.Core.ConfigModel
{
    public class ConfigIngressBinding
    {
        public string? Name { get; set; }
        public int? Port { get; set; }
        public string? Protocol { get; set; } // HTTP or HTTPS
        public string? IPAddress { get; set; } // Can be * or any address to listen on
    }
}
