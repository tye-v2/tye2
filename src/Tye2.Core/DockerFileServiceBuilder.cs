

using System.Collections.Generic;

namespace Tye2.Core
{
    public class DockerFileServiceBuilder : ProjectServiceBuilder
    {
        public DockerFileServiceBuilder(string name, string image, ServiceSource source)
            : base(name, source)
        {
            Image = image;
        }
        public string Image { get; }

        public string? DockerFile { get; set; }
        public Dictionary<string, string> BuildArgs { get; set; } = new Dictionary<string, string>();

        public string? DockerFileContext { get; set; }
    }
}
