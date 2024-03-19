using System;
using System.Runtime.InteropServices;
using Tye2.Core;

namespace Tye2.Test.Infrastructure
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Assembly)]
    public class SkipIfDockerNotRunningAttribute : Attribute, ITestCondition
    {
        public SkipIfDockerNotRunningAttribute()
        {
            // TODO Check performance of this.
            IsMet = ContainerEngine.Default.IsUsable(out string unusableReason) && !(RuntimeInformation.IsOSPlatform(OSPlatform.Windows) && !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("AGENT_OS")));
            SkipReason = $"Container engine not usable: {unusableReason}";
        }

        public bool IsMet { get; }

        public string SkipReason { get; set; }
    }
}
