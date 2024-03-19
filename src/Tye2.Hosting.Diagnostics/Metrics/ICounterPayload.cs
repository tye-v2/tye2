

namespace Tye2.Hosting.Diagnostics.Metrics
{
    internal interface ICounterPayload
    {
        public string Name { get; }
        public string Value { get; }
    }
}
