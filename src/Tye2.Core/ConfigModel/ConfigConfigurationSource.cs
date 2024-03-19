

using System.ComponentModel.DataAnnotations;

namespace Tye2.Core.ConfigModel
{
    public class ConfigConfigurationSource
    {
        [Required]
        public string Name { get; set; } = default!;

        [Required]
        public string Value { get; set; } = default!;
    }
}
