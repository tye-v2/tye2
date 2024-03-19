


using System.Reflection;
using Tye2.Test.Infrastructure.Logging;
using Xunit.Abstractions;

namespace Tye2.Test.Infrastructure
{
    public class LoggedTest : LoggedTestBase
    {
        // Obsolete but keeping for back compat
        public LoggedTest(ITestOutputHelper output = null) : base(output) { }

        public ITestSink TestSink { get; set; }

        public override void Initialize(TestContext context, MethodInfo methodInfo, object[] testMethodArguments, ITestOutputHelper testOutputHelper)
        {
            base.Initialize(context, methodInfo, testMethodArguments, testOutputHelper);

            TestSink = new TestSink();
            LoggerFactory.AddProvider(new TestLoggerProvider(TestSink));
        }
    }
}
