

using System.Collections.Generic;

namespace Tye2.Core
{
    public sealed class ExtensionConfiguration
    {
        public ExtensionConfiguration(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public Dictionary<string, object> Data { get; } = new Dictionary<string, object>();
    }
}
