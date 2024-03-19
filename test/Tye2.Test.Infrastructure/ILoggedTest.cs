using System;
using System.Reflection;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace Tye2.Test.Infrastructure
{
    public interface ILoggedTest : IDisposable
    {
        ILogger Logger { get; }

        ILoggerFactory LoggerFactory { get; }

        ITestOutputHelper TestOutputHelper { get; }

        // For back compat
        IDisposable StartLog(out ILoggerFactory loggerFactory, LogLevel minLogLevel, string testName);

        void Initialize(TestContext context, MethodInfo methodInfo, object[] testMethodArguments, ITestOutputHelper testOutputHelper);
    }
}
