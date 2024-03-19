﻿using System.Collections.Generic;
using System.IO;

namespace Tye2.Core
{
    public sealed class ApplicationBuilder
    {
        public ApplicationBuilder(FileInfo source, string name, ContainerEngine containerEngine, int? dashboardPort)
        {
            Source = source;
            Name = name;
            ContainerEngine = containerEngine;
            DashboardPort = dashboardPort;
        }

        public FileInfo Source { get; }

        public string Name { get; }

        public int? DashboardPort { get; set; }

        public string? Namespace { get; set; }

        public ContainerRegistry? Registry { get; set; }

        public ContainerEngine ContainerEngine { get; set; }

        public List<ExtensionConfiguration> Extensions { get; } = new List<ExtensionConfiguration>();

        public List<ServiceBuilder> Services { get; } = new List<ServiceBuilder>();

        public List<IngressBuilder> Ingress { get; } = new List<IngressBuilder>();

        public string? Network { get; set; }
        public string? BuildSolution { get; internal set; }
    }
}
