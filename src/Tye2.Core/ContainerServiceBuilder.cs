﻿

using System.Collections.Generic;

namespace Tye2.Core
{
    public sealed class ContainerServiceBuilder : ServiceBuilder
    {
        public ContainerServiceBuilder(string name, string image, ServiceSource source)
            : base(name, source)
        {
            Image = image;
        }

        public string Image { get; }

        public bool IsAspNet { get; set; }

        public string? Args { get; set; }

        public int Replicas { get; set; } = 1;

        public List<EnvironmentVariableBuilder> EnvironmentVariables { get; } = new List<EnvironmentVariableBuilder>();

        public List<VolumeBuilder> Volumes { get; } = new List<VolumeBuilder>();

        public ProbeBuilder? Liveness { get; set; }

        public ProbeBuilder? Readiness { get; set; }
    }
}
