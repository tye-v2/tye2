

using System.Collections.Generic;
using System.IO;

namespace Tye2.Hosting.Model
{
    public class DockerRunInfo : RunInfo
    {
        public DockerRunInfo(string image, string? args)
        {
            Image = image;
            Args = args;
        }

        public bool IsProxy { get; set; }

        public bool Private { get; set; }

        public bool IsAspNet { get; set; }

        public string? NetworkAlias { get; set; }

        public string? WorkingDirectory { get; set; }

        public List<DockerVolume> VolumeMappings { get; } = new List<DockerVolume>();

        public string? Args { get; }

        public Dictionary<string, string> BuildArgs { get; set; } = new Dictionary<string, string>();

        public string Image { get; }

        public FileInfo? DockerFile { get; set; }

        public FileInfo? DockerFileContext { get; set; }
    }
}
