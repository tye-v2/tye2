

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tye2.Core.ConfigModel
{
    public class ConfigIngress
    {
        [Required]
        public string Name { get; set; } = default!;
        public int? Replicas { get; set; }
        public List<ConfigIngressRule> Rules { get; set; } = new List<ConfigIngressRule>();
        public List<ConfigIngressBinding> Bindings { get; set; } = new List<ConfigIngressBinding>();
        public List<string> Tags { get; set; } = new List<string>();
    }
}
