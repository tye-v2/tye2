using System;
using System.Linq;
using Tye2.Core;

namespace Tye2.Hosting
{
    public class ProcessRunnerOptions
    {
        public const string AllServices = "*";

        public bool BuildProjects { get; set; }

        public bool DebugMode { get; set; }
        public string[]? ServicesToDebug { get; set; }
        public bool DebugAllServices { get; set; }
        public bool ShouldDebugService (string serviceName) => DebugMode && (DebugAllServices || ServicesToDebug!.Contains(serviceName, StringComparer.OrdinalIgnoreCase));
        public bool ManualStartServices { get; set; }
        public string[]? ServicesNotToStart { get; set; }

        public bool WatchMode { get; set; }
        public string[]? ServicesToWatch { get; set; }
        public bool WatchAllServices { get; set; }
        public bool ShouldWatchService(string serviceName) => WatchMode && (WatchAllServices || ServicesToWatch!.Contains(serviceName, StringComparer.OrdinalIgnoreCase));

        public static ProcessRunnerOptions FromHostOptions(HostOptions options)
        {
            return new ProcessRunnerOptions
            {
                BuildProjects = !options.NoBuild,
                
                DebugMode = options.Debug.Any(),
                ServicesToDebug = options.Debug.ToArray(),
                DebugAllServices = options.Debug?.Contains(AllServices, StringComparer.OrdinalIgnoreCase) ?? false,
                
                WatchMode = options.Watch.Any(),
                ServicesToWatch = options.Watch.ToArray(),
                WatchAllServices = options.Watch?.Contains(AllServices, StringComparer.OrdinalIgnoreCase) ?? false,
                ManualStartServices = options.NoStart?.Contains(AllServices, StringComparer.OrdinalIgnoreCase) ?? false,
                ServicesNotToStart = options.NoStart?.ToArray(),
            };
        }
    }
}
