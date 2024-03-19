

using System.Collections.Generic;

namespace Tye2.Hosting.Model
{
    public class IngressRunInfo : RunInfo
    {
        public IngressRunInfo(List<IngressRule> rules)
        {
            Rules = rules;
        }

        public List<IngressRule> Rules { get; }
    }
}
