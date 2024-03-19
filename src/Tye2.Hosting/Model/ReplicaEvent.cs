

namespace Tye2.Hosting.Model
{
    public readonly struct ReplicaEvent
    {
        public ReplicaState State { get; }
        public ReplicaStatus Replica { get; }

        public ReplicaEvent(ReplicaState state, ReplicaStatus replica)
        {
            State = state;
            Replica = replica;
        }
    }
}
