

namespace Tye2.Hosting.Model
{
    public class ServiceStatus
    {
        public string? ProjectFilePath { get; set; }
        public string? ExecutablePath { get; set; }
        public string? Args { get; set; }
        public string? WorkingDirectory { get; set; }
    }
}
