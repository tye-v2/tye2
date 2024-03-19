

namespace Tye2.Hosting.Model.V1
{
    public class V1ServiceBinding
    {
        public string? Name { get; set; }
        public string? ConnectionString { get; set; }
        public bool AutoAssignPort { get; set; }
        public int? Port { get; set; }
        public int? ContainerPort { get; set; }
        public string? Host { get; set; }
        public string? Protocol { get; set; }
    }
}
