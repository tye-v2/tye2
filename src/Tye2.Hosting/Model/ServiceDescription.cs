

using System.Collections.Generic;

namespace Tye2.Hosting.Model
{
    public class ServiceDescription
    {
        public ServiceDescription(string name, RunInfo? runInfo)
        {
            Name = name;
            RunInfo = runInfo;
        }

        public string Name { get; }
        public RunInfo? RunInfo { get; set; }
        public int Replicas { get; set; } = 1;
        public List<ServiceBinding> Bindings { get; } = new List<ServiceBinding>();
        public List<EnvironmentVariable> Configuration { get; } = new List<EnvironmentVariable>();
        public List<string> Dependencies { get; } = new List<string>();
        public Probe? Liveness { get; set; }
        public Probe? Readiness { get; set; }
    }
}
