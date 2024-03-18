using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Microsoft.Tye.Proxy;

internal static class ServiceProviderExtensions
{
    internal static ILoggerFactory GetLoggerFactory(this IServiceProvider serviceProvider)
    {
        return (ILoggerFactory)serviceProvider?.GetService(typeof(ILoggerFactory)) ?? NullLoggerFactory.Instance;
    }
}

