using System;
using System.Runtime.InteropServices;

namespace Tye2.Test.Infrastructure
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Assembly)]
    internal class SkipOnLinuxAttribute : Attribute, ITestCondition
    {
        public SkipOnLinuxAttribute()
        {
            IsMet = !RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
            SkipReason = "This is linux. Here's a free bus-ticket to skipsville.";
        }

        public bool IsMet { get; }

        public string SkipReason { get; set; }
    }
}
