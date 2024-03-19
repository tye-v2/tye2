

using System.Threading.Tasks;

namespace Tye2.Core
{
    public abstract class Extension
    {
        public abstract Task ProcessAsync(ExtensionContext context, ExtensionConfiguration config);
    }
}
