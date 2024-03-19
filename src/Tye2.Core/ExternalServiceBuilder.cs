

namespace Tye2.Core
{
    public sealed class ExternalServiceBuilder : ServiceBuilder
    {
        public ExternalServiceBuilder(string name, ServiceSource source)
            : base(name, source)
        {
        }
    }
}
