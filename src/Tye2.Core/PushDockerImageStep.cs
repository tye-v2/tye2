﻿

using System.Linq;
using System.Threading.Tasks;

namespace Tye2.Core
{
    public sealed class PushDockerImageStep : ApplicationExecutor.ServiceStep
    {
        public override string DisplayText => "Pushing Docker Image...";

        public string Environment { get; set; } = "production";

        public override async Task ExecuteAsync(OutputContext output, ApplicationBuilder application, ServiceBuilder service)
        {
            if (SkipWithoutProject(output, service, out var _))
            {
                return;
            }

            if (SkipWithoutContainerInfo(output, service, out var _))
            {
                return;
            }

            foreach (var image in service.Outputs.OfType<DockerImageOutput>())
            {
                await DockerPush.ExecuteAsync(output, application.ContainerEngine, image.ImageName, image.ImageTag);
                output.WriteInfoLine($"Pushed docker image: '{image.ImageName}:{image.ImageTag}'");
            }
        }
    }
}
