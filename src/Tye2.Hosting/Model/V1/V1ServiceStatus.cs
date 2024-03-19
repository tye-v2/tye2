

namespace Tye2.Hosting.Model.V1
{
    public class V1ServiceStatus
    {
        public string? ProjectFilePath { get; set; }
        public string? ExecutablePath { get; set; }
        public string? Args { get; set; }
        public string? WorkingDirectory { get; set; }
    }
}
