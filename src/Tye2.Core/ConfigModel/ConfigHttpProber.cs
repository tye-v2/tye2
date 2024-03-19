

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tye2.Core.ConfigModel
{
    public class ConfigHttpProber
    {
        [Required] public string Path { get; set; } = default!;
        public int? Port { get; set; }
        public string? Protocol { get; set; }
        public List<KeyValuePair<string, object>> Headers { get; set; } = new List<KeyValuePair<string, object>>();
    }
}
