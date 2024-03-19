

using System.Collections.Generic;

namespace Tye2.Hosting.Model.V1
{
    public class V1RunInfo
    {
        public V1RunInfoType Type { get; set; }
        public string? Args { get; set; }
        public bool Build { get; set; }
        public string? Project { get; set; }
        public string? WorkingDirectory { get; set; }
        public List<V1DockerVolume>? VolumeMappings { get; set; }
        public string? Image { get; set; }
        public string? Executable { get; set; }
    }
}
