using System;

namespace Tye2.Core
{
    public sealed class Project : Source
    {
        public Project(string relativeFilePath)
        {
            RelativeFilePath = relativeFilePath ?? throw new ArgumentNullException(nameof(relativeFilePath));
        }

        public string RelativeFilePath { get; }

        public FrameworkCollection Frameworks { get; } = new FrameworkCollection();

        public string TargetFramework { get; set; } = default!;

        public string Version { get; set; } = default!;
    }
}
