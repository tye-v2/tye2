﻿

using Microsoft.Extensions.Logging;

namespace Tye2.Test.Infrastructure.Logging
{
    public class TestLoggerFactory : ILoggerFactory
    {
        private readonly ITestSink _sink;
        private readonly bool _enabled;

        public TestLoggerFactory(ITestSink sink, bool enabled)
        {
            _sink = sink;
            _enabled = enabled;
        }

        public ILogger CreateLogger(string name)
        {
            return new TestLogger(name, _sink, _enabled);
        }

        public void AddProvider(ILoggerProvider provider)
        {
        }

        public void Dispose()
        {
        }
    }
}
