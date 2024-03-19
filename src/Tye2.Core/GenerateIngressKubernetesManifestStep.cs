

using System.Threading.Tasks;

namespace Tye2.Core
{
    public sealed class GenerateIngressKubernetesManifestStep : ApplicationExecutor.IngressStep
    {
        public override string DisplayText => "Generating Manifests...";

        public string Environment { get; set; } = "production";

        public override async Task ExecuteAsync(OutputContext output, ApplicationBuilder application, IngressBuilder ingress)
        {
            ingress.Outputs.Add(await KubernetesManifestGenerator.CreateIngress(output, application, ingress));
        }
    }
}
