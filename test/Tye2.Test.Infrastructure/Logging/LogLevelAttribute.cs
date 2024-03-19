using System;
using Microsoft.Extensions.Logging;

namespace Tye2.Test.Infrastructure.Logging
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Assembly, AllowMultiple = false)]
    public class LogLevelAttribute : Attribute
    {
        public LogLevelAttribute(LogLevel logLevel)
        {
            LogLevel = logLevel;
        }

        public LogLevel LogLevel { get; }
    }
}
