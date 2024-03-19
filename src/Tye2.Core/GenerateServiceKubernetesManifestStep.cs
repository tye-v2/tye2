

using System.Threading.Tasks;

namespace Tye2.Core
{
    public sealed class GenerateServiceKubernetesManifestStep : ApplicationExecutor.ServiceStep
    {
        public override string DisplayText => "Generating Manifests...";

        public string Environment { get; set; } = "production";


        public override Task ExecuteAsync(OutputContext output, ApplicationBuilder application, ServiceBuilder service)
        {
            if (SkipWithoutContainerOutput(output, service))
            {
                return Task.CompletedTask;
            }

            if (SkipWithoutProject(output, service, out var project))
            {
                return Task.CompletedTask;
            }

            var deployment = project.ManifestInfo?.Deployment;
            if (deployment is null)
            {
                return Task.CompletedTask;
            }

            // Initialize defaults for deployment-related settings
            deployment.Labels.TryAdd("app.kubernetes.io/name", project.Name);
            deployment.Labels.TryAdd("app.kubernetes.io/part-of", application.Name);

            service.Outputs.Add(KubernetesManifestGenerator.CreateDeployment(output, application, project, deployment));

            if (service.Bindings.Count > 0 &&
                project.ManifestInfo?.Service is ServiceManifestInfo k8sService)
            {
                // Initialize defaults for service-related settings
                k8sService.Labels.TryAdd("app.kubernetes.io/name", project.Name);
                k8sService.Labels.TryAdd("app.kubernetes.io/part-of", application.Name);

                service.Outputs.Add(KubernetesManifestGenerator.CreateService(output, application, project, deployment, k8sService));
            }

            return Task.CompletedTask;
        }
    }
}
