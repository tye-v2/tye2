using System;
using System.Linq;
using Tye2.Core;

namespace Tye2.Hosting
{
    public class DockerRunnerOptions
    {
        public bool ManualStartServices { get; set; }
        public string[]? ServicesNotToStart { get; set; }

        public static DockerRunnerOptions FromHostOptions(HostOptions options)
        {
            return new DockerRunnerOptions
            {
                ManualStartServices = options.NoStart?.Contains("*", StringComparer.OrdinalIgnoreCase) ?? false,
                ServicesNotToStart = options.NoStart?.ToArray()
            };
        }
    }
}
