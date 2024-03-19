using System;
using System.Linq;
using Tye2.Core.ConfigModel;

namespace Tye2.Core
{
    public class ApplicationFactoryFilter
    {
        public Func<ConfigService, bool>? ServicesFilter { get; set; }
        public Func<ConfigIngress, bool>? IngressFilter { get; set; }

        public static ApplicationFactoryFilter? GetApplicationFactoryFilter(string[] tags)
        {
            ApplicationFactoryFilter? filter = null;

            if (tags != null && tags.Any())
            {
                filter = new ApplicationFactoryFilter
                {
                    ServicesFilter = service => tags.Any(b => service.Tags.Contains(b)),
                    IngressFilter = service => tags.Any(b => service.Tags.Contains(b))
                };
            }

            return filter;
        }
    }
}
