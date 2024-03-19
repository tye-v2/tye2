﻿

using System.Collections.Generic;

namespace Tye2.Core
{
    public class HostOptions
    {
        public bool Dashboard { get; set; }

        public List<string> Debug { get; } = new List<string>();
        public List<string> Watch { get; } = new List<string>();

        public List<string> NoStart { get; } = new List<string>();

        public string? DistributedTraceProvider { get; set; }

        public bool Docker { get; set; }

        public string? LoggingProvider { get; set; }

        public string? MetricsProvider { get; set; }

        public bool NoBuild { get; set; }

        public int? Port { get; set; }

        public Verbosity LogVerbosity { get; set; } = Verbosity.Debug;
    }
}
