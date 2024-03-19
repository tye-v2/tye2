

namespace Tye2.Hosting.Model
{
    public class DockerStatus : ReplicaStatus
    {
        public DockerStatus(Service service, string name) : base(service, name)
        {
        }

        public string? DockerCommand { get; set; }

        public string? DockerNetwork { get; set; }

        public string? DockerNetworkAlias { get; set; }

        public string? ContainerId { get; set; }
    }
}
