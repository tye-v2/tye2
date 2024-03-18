namespace Tye2.Hosting.Model
{
    public class DockerVolume
    {
        public DockerVolume(string? source, string? name, string target, bool readOnly = false)
        {
            Source = source;
            Name = name;
            Target = target;
            ReadOnly = readOnly;
        }

        public string? Name { get; }
        public string? Source { get; }
        public string Target { get; }
        public bool ReadOnly { get; }
    }
}
