using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;

namespace Tye2.E2ETests.Infrastructure;

public interface IZipkinClient
{
    [Get("/services")]
    public Task<IReadOnlyList<string>> GetServices();
    [Get("/traces")]
    public Task<IReadOnlyList<IReadOnlyList<ZipkinTrace>>> GetTraces(string serviceName);
}
public record ZipkinTrace
{
    public string TraceId { get; init; }
    public string ParentId { get; init; }
    public string Id { get; init; }
    public string Name { get; init; }
    public string Kind { get; init; }
    public LocalEndpoint LocalEndpoint { get; init; }
}

public record LocalEndpoint
{
    public string ServiceName { get; init; }
}
