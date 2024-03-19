using System;
using Xunit;
using Xunit.Sdk;

namespace Tye2.Test.Infrastructure
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    [XunitTestCaseDiscoverer("Tye2.Test.Infrastructure." + nameof(ConditionalFactDiscoverer), "Tye2.Test.Infrastructure")]
    public class ConditionalFactAttribute : FactAttribute
    {
    }
}
