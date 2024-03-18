using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.AspNetCore.Connections;

namespace Microsoft.Tye.Proxy;

public class ServerBuilder
{
    public ServerBuilder() : this(EmptyServiceProvider.Instance)
    {

    }

    public ServerBuilder(IServiceProvider serviceProvider)
    {
        ApplicationServices = serviceProvider;
    }

    public IList<ServerBinding> Bindings { get; } = new List<ServerBinding>();

    public TimeSpan ShutdownTimeout { get; set; } = TimeSpan.FromSeconds(5);

    public TimeSpan HeartBeatInterval { get; set; } = TimeSpan.FromSeconds(1);

    public IServiceProvider ApplicationServices { get; }

    public Server Build()
    {
        return new Server(this);
    }
}
public abstract class ServerBinding
{
    public virtual ConnectionDelegate Application { get; }

    public abstract IAsyncEnumerable<IConnectionListener> BindAsync(CancellationToken cancellationToken = default);
}
