using System;
using YamlDotNet.RepresentationModel;

namespace Tye2.Core
{
    internal sealed class KubernetesIngressOutput : IngressOutput, IYamlManifestOutput
    {
        public KubernetesIngressOutput(string name, YamlDocument yaml)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Yaml = yaml ?? throw new ArgumentNullException(nameof(yaml));
        }

        public string Name { get; }
        public YamlDocument Yaml { get; }
    }
}
