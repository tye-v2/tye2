

using System.Threading.Tasks;

namespace Tye2.Core
{
    internal sealed class GenerateOamComponentStep : ApplicationExecutor.ServiceStep
    {
        public override string DisplayText => "Generating Manifests...";

        public string Environment { get; set; } = "production";


        public override Task ExecuteAsync(OutputContext output, ApplicationBuilder application, ServiceBuilder service)
        {
            if (SkipWithoutContainerOutput(output, service))
            {
                return Task.CompletedTask;
            }

            if (SkipWithoutDotnetProject(output, service, out var project))
            {
                return Task.CompletedTask;
            }

            var component = OamComponentGenerator.CreateOamComponent(output, application, project);
            service.Outputs.Add(component);
            return Task.CompletedTask;
        }
    }
}
