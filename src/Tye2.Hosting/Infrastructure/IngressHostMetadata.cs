

using System.Collections.Generic;

namespace Tye2.Hosting.Infrastructure
{
    internal class IngressHostMetadata
    {
        public IngressHostMetadata(params string[] hosts)
        {
            Hosts = new List<string>(hosts).AsReadOnly();
        }

        public IReadOnlyList<string> Hosts { get; }
    }
}
