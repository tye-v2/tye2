

using System.Threading;
using System.Threading.Tasks;

namespace Tye2.Hosting.Watch
{
    public interface IFileSetFactory
    {
        Task<IFileSet> CreateAsync(CancellationToken cancellationToken);
    }
}
