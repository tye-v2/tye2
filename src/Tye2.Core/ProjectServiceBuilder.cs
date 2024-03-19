

using System.Collections.Generic;

namespace Tye2.Core
{
    public class ProjectServiceBuilder : LaunchedServiceBuilder
    {
        public ProjectServiceBuilder(string name, ServiceSource source)
            : base(name, source)
        {
        }
        public bool IsAspNet { get; set; }

        public bool Build { get; set; }

        public string? Args { get; set; }

        // Data used for building containers
        public ContainerInfo? ContainerInfo { get; set; }

        // Data used for building Kubernetes manifests
        public KubernetesManifestInfo? ManifestInfo { get; set; }

        // Used when running in a container locally.
        public List<VolumeBuilder> Volumes { get; } = new List<VolumeBuilder>();

        public List<SidecarBuilder> Sidecars { get; } = new List<SidecarBuilder>();

        public ProbeBuilder? Liveness { get; set; }

        public ProbeBuilder? Readiness { get; set; }

        public bool RelocateDiagnosticsDomainSockets { get; set; }
    }
}
