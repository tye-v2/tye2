

using System.Collections.Generic;

namespace Tye2.Core
{
    public sealed class DeploymentManifestInfo
    {
        public Dictionary<string, string> Annotations { get; } = new Dictionary<string, string>();

        public Dictionary<string, string> Labels { get; } = new Dictionary<string, string>();
    }
}
