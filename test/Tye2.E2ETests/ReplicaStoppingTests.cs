using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Tye2.Core;
using Tye2.Hosting;
using Tye2.Hosting.Model;
using Tye2.Test.Infrastructure;
using Xunit;
using Xunit.Abstractions;
using static Tye2.Test.Infrastructure.TestHelpers;

namespace Tye2.E2ETests
{
    public class ReplicaStoppingTests
    {
        private readonly ITestOutputHelper _output;
        private readonly TestOutputLogEventSink _sink;
        private readonly JsonSerializerOptions _options;

        private static readonly ReplicaState?[] startedOrHigher = new ReplicaState?[] { ReplicaState.Started, ReplicaState.Healthy, ReplicaState.Ready };
        private static readonly ReplicaState?[] stoppedOrLower = new ReplicaState?[] { ReplicaState.Stopped, ReplicaState.Removed };

        public ReplicaStoppingTests(ITestOutputHelper output)
        {
            _output = output;
            _sink = new TestOutputLogEventSink(output);

            _options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };

            _options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
        }

        [Fact]
        public async Task MultiProjectStoppingTests()
        {
            using var projectDirectory = CopyTestProjectDirectory("health-checks");

            var projectFile = new FileInfo(Path.Combine(projectDirectory.DirectoryPath, "tye-none.yaml"));
            var outputContext = new OutputContext(_sink, Verbosity.Debug);
            var application = await ApplicationFactory.CreateAsync(outputContext, projectFile);

            await RunHostingApplication(application, new HostOptions(), async (host, uri) =>
            {
                var replicaToStop = host.Application.Services["health-none"].Replicas.First();
                Assert.Contains(replicaToStop.Value.State, startedOrHigher);

                var replicasToRestart = new[] { replicaToStop.Key };
                var restOfReplicas = host.Application.Services.SelectMany(s => s.Value.Replicas).Select(r => r.Value.Name).Where(r => r != replicaToStop.Key).ToArray();

                Assert.True(await DoOperationAndWaitForReplicasToRestart(host, replicasToRestart.ToHashSet(), restOfReplicas.ToHashSet(), TimeSpan.FromSeconds(30), _ =>
                {
                    replicaToStop.Value.StoppingTokenSource!.Cancel();
                    return Task.CompletedTask;
                }));

                Assert.Contains(replicaToStop.Value.State, stoppedOrLower);
                Assert.True(host.Application.Services.SelectMany(s => s.Value.Replicas).All(r => startedOrHigher.Contains(r.Value.State)));
            });
        }

        [ConditionalFact]
        [SkipIfDockerNotRunning]
        [Trait("FailsAfterNet8", "true")]
        [Trait("FailsInGithubActions", "true")]
        public async Task MultiProjectDockerStoppingTests()
        {
            using var projectDirectory = CopyTestProjectDirectory("multi-project");

            var projectFile = new FileInfo(Path.Combine(projectDirectory.DirectoryPath, "tye.yaml"));
            var outputContext = new OutputContext(_sink, Verbosity.Debug);
            var application = await ApplicationFactory.CreateAsync(outputContext, projectFile);

            await RunHostingApplication(application, new HostOptions() { Docker = true }, async (host, uri) =>
              {
                  var replicaToStop = host.Application.Services["frontend"].Replicas.First();
                  Assert.Contains(replicaToStop.Value.State, startedOrHigher);

                  var replicasToRestart = new[] { replicaToStop.Key };
                  var restOfReplicas = host.Application.Services.SelectMany(s => s.Value.Replicas).Select(r => r.Value.Name).Where(r => r != replicaToStop.Key).ToArray();

                  Assert.True(await DoOperationAndWaitForReplicasToRestart(host, replicasToRestart.ToHashSet(), restOfReplicas.ToHashSet(), TimeSpan.FromSeconds(1), _ =>
                  {
                      replicaToStop.Value.StoppingTokenSource!.Cancel();
                      return Task.CompletedTask;
                  }));

                  Assert.Contains(replicaToStop.Value.State, startedOrHigher); // when a container restarts, it assumes the same replica
                  Assert.True(host.Application.Services.SelectMany(s => s.Value.Replicas).All(r => startedOrHigher.Contains(r.Value.State)));
              });
        }

        private async Task RunHostingApplication(ApplicationBuilder application, HostOptions options, Func<TyeHost, Uri, Task> execute)
        {
            await using var host = new TyeHost(application.ToHostingApplication(), options)
            {
                Sink = _sink,
            };

            try
            {
                await StartHostAndWaitForReplicasToStart(host);

                var uri = new Uri(host.Addresses!.First());

                await execute(host, uri!);
            }
            finally
            {
                if (host.DashboardWebApplication != null)
                {
                    var uri = new Uri(host.Addresses!.First());

                    using var client = new HttpClient();

                    foreach (var s in host.Application.Services.Values)
                    {
                        var logs = await client.GetStringAsync(new Uri(uri, $"/api/v1/logs/{s.Description.Name}"));

                        _output.WriteLine($"Logs for service: {s.Description.Name}");
                        _output.WriteLine(logs);

                        var description = await client.GetStringAsync(new Uri(uri, $"/api/v1/services/{s.Description.Name}"));

                        _output.WriteLine($"Service defintion: {s.Description.Name}");
                        _output.WriteLine(description);
                    }
                }
            }
        }
    }
}
