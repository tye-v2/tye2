

namespace Tye2.Core
{
    public sealed class VolumeBuilder
    {
        public VolumeBuilder(string? source, string? name, string target)
        {
            Source = source;
            Name = name;
            Target = target;
        }

        public string? Source { get; }

        public string? Name { get; }

        public string Target { get; }
    }
}
