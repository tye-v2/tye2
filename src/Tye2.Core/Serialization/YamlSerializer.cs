

using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Tye2.Core.Serialization
{
    public static class YamlSerializer
    {
        public static ISerializer CreateSerializer()
        {
            return new SerializerBuilder()
                    .WithNamingConvention(CamelCaseNamingConvention.Instance)
                    .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitDefaults)
                    .WithEmissionPhaseObjectGraphVisitor(args => new OmitDefaultAndEmptyArrayObjectGraphVisitor(args.InnerVisitor))
                    .Build();
        }
    }
}
