

using System.Collections.Generic;

namespace Tye2.Hosting.Model.V1
{
    public class V1ReplicaStatus
    {
        public string? DockerCommand { get; set; }
        public string? ContainerId { get; set; }
        public string? DockerNetwork { get; set; }
        public string? DockerNetworkAlias { get; set; }
        public string? Name { get; set; }
        public IEnumerable<int>? Ports { get; set; }
        public int? ExitCode { get; set; }
        public int? Pid { get; set; }
        public IDictionary<string, string>? Environment { get; set; }
        public ReplicaState? State { get; set; }
    }
}
