

using System.Collections.Generic;
using Tye2.Core;

namespace Tye2.Hosting.Model.V1
{
    public class V1Service
    {
        public V1ServiceDescription? Description { get; set; }
        public ServiceSource ServiceSource { get; set; }
        public ServiceType ServiceType { get; set; }
        public int Restarts { get; set; }
        public V1ServiceStatus? Status { get; set; }
        public Dictionary<string, V1ReplicaStatus>? Replicas { get; set; }
    }
}
