

using YamlDotNet.RepresentationModel;

namespace Tye2.Core
{
    internal interface IYamlManifestOutput
    {
        YamlDocument Yaml { get; }
    }
}
