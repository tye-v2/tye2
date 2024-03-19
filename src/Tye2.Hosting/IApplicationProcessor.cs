

using System.Threading.Tasks;
using Tye2.Hosting.Model;

namespace Tye2.Hosting
{
    public interface IApplicationProcessor
    {
        Task StartAsync(Application application);

        Task StopAsync(Application application);
    }
}
