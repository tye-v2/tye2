

using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Tye2.Test.Infrastructure
{
    internal class ConditionalTheoryDiscoverer : TheoryDiscoverer
    {
        private readonly IMessageSink _diagnosticMessageSink;

        public ConditionalTheoryDiscoverer(IMessageSink diagnosticMessageSink)
            : base(diagnosticMessageSink)
        {
            _diagnosticMessageSink = diagnosticMessageSink;
        }

        protected override IEnumerable<IXunitTestCase> CreateTestCasesForTheory(
            ITestFrameworkDiscoveryOptions discoveryOptions,
            ITestMethod testMethod,
            IAttributeInfo theoryAttribute)
        {
            var skipReason = testMethod.EvaluateSkipConditions();
            return skipReason != null
                       ? new IXunitTestCase[]
                         {
                             new SkippedTestCase(
                                 skipReason,
                                 _diagnosticMessageSink,
                                 discoveryOptions.MethodDisplayOrDefault(),
                                 TestMethodDisplayOptions.None,
                                 testMethod)
                         }
                       : base.CreateTestCasesForTheory(discoveryOptions, testMethod, theoryAttribute);
        }
    }
}
