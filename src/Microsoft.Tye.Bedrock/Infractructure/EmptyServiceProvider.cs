using System;

namespace Microsoft.Tye.Proxy;

internal class EmptyServiceProvider : IServiceProvider
{
    public static IServiceProvider Instance { get; } = new EmptyServiceProvider();

    public object GetService(Type serviceType) => null;
}
