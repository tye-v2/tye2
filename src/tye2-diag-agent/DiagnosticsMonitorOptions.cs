

using System.Collections.Generic;
using Tye2.Hosting.Diagnostics;

namespace Tye2.DiagAgent
{
    public class DiagnosticsMonitorOptions
    {
        public bool Kubernetes { get; set; }

        public string Service { get; set; } = default!;

        public string AssemblyName { get; set; } = default!;

        public List<DiagnosticsProvider> Providers { get; } = new List<DiagnosticsProvider>();
    }
}
