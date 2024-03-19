

namespace Tye2.Hosting.Model
{
    public class IngressStatus : ReplicaStatus
    {
        public IngressStatus(Service service, string name) : base(service, name)
        {
        }

    }
}
