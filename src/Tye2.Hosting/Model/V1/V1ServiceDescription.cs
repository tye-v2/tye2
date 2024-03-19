

using System.Collections.Generic;

namespace Tye2.Hosting.Model.V1
{
    public class V1ServiceDescription
    {
        public string? Name { get; set; }
        public int Replicas { get; set; }
        public V1RunInfo? RunInfo { get; set; }
        public List<V1ServiceBinding>? Bindings { get; set; }
        public List<V1ConfigurationSource>? Configuration { get; set; }
    }
}
