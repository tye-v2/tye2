

namespace Tye2.Core
{
    public sealed class KubernetesManifestInfo
    {
        public KubernetesManifestInfo()
        {
            // Create deployment and service by default
            Deployment = new DeploymentManifestInfo();
            Service = new ServiceManifestInfo();
        }

        public DeploymentManifestInfo? Deployment { get; }

        public ServiceManifestInfo Service { get; }
    }
}
