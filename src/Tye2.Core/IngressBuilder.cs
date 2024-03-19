

using System.Collections.Generic;

namespace Tye2.Core
{
    public sealed class IngressBuilder
    {
        public IngressBuilder(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public int Replicas { get; set; } = 1;

        public List<IngressBindingBuilder> Bindings { get; set; } = new List<IngressBindingBuilder>();

        public List<IngressRuleBuilder> Rules { get; set; } = new List<IngressRuleBuilder>();

        public List<IngressOutput> Outputs { get; } = new List<IngressOutput>();
    }
}
