

namespace Tye2.Hosting.Model
{
    public class ProcessStatus : ReplicaStatus
    {
        public ProcessStatus(Service service, string name)
            : base(service, name)
        {
        }

        public int? ExitCode { get; set; }
        public int? Pid { get; set; }
    }
}
