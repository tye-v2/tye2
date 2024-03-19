

using System.Collections.Generic;

namespace Tye2.Hosting.Diagnostics.Metrics
{
    internal class IncrementingCounterPayload : ICounterPayload
    {
        public IncrementingCounterPayload(IDictionary<string, object> payloadFields)
        {
            Name = payloadFields["Name"].ToString()!;
            Value = payloadFields["Increment"].ToString()!;
        }

        public string Name { get; }
        public string Value { get; }
    }
}
