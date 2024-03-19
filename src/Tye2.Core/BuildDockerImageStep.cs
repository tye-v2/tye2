using System.Threading.Tasks;

namespace Tye2.Core
{
    public sealed class BuildDockerImageStep : ApplicationExecutor.ServiceStep
    {
        public override string DisplayText => "Building Docker Image...";

        public string Environment { get; set; } = "production";

        public override async Task ExecuteAsync(OutputContext output, ApplicationBuilder application, ServiceBuilder service)
        {
            if (SkipWithoutProject(output, service, out var project))
            {
                return;
            }

            if (SkipWithoutContainerInfo(output, service, out var container))
            {
                return;
            }

            if (!application.ContainerEngine.IsUsable(out string? unusableReason))
            {
                throw new CommandException($"Cannot generate a docker image for '{service.Name}' because {unusableReason}.");
            }

            if (project is DotnetProjectServiceBuilder dotnetProject)
            {
                await DockerContainerBuilder.BuildContainerImageAsync(output, application, dotnetProject, container);
            }
            else if (project is DockerFileServiceBuilder dockerFile)
            {
                await DockerContainerBuilder.BuildContainerImageFromDockerFileAsync(output, application, dockerFile, container);
            }
        }
    }
}
