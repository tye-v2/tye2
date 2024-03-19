using System;

namespace Tye2.Core
{
    public sealed class Framework
    {
        public Framework(string name)
        {
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
        }

        public string Name { get; }
    }
}
