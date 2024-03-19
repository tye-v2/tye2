using System;

namespace Tye2.Core
{
    public sealed class ContainerRegistry
    {
        public ContainerRegistry(string hostname, string? pullSecret)
        {
            Hostname = hostname ?? throw new ArgumentNullException(nameof(hostname));
            PullSecret = pullSecret;
        }

        public string Hostname { get; }
        public string? PullSecret { get; }
    }
}
