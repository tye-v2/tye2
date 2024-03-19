

using System.ComponentModel.DataAnnotations;

namespace Tye2.Core.ConfigModel
{
    public class ConfigVolume
    {
        public string Source { get; set; } = default!;

        public string Name { get; set; } = default!;

        [Required]
        public string Target { get; set; } = default!;
    }
}
