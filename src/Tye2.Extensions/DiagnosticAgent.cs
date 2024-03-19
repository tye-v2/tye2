

using System.Linq;
using Tye2.Core;

namespace Tye2.Extensions
{
    public static class DiagnosticAgent
    {
        public static SidecarBuilder GetOrAddSidecar(DotnetProjectServiceBuilder project)
        {
            // Bring your rain boots.
            project.RelocateDiagnosticsDomainSockets = true;

            var sidecar = project.Sidecars.FirstOrDefault(s => s.Name == "tye-diag-agent");
            if (sidecar != null)
            {
                return sidecar;
            }

            sidecar = new SidecarBuilder("tye-diag-agent", "rynowak/tye-diag-agent", "0.1")
            {
                Args =
                {
                    "--kubernetes=true",
                    $"--service={project.Name}",
                    $"--assemblyName={project.AssemblyName}",
                },
            };
            project.Sidecars.Add(sidecar);
            return sidecar;
        }
    }
}
