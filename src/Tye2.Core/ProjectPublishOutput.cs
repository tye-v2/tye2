

using System.IO;

namespace Tye2.Core
{
    public class ProjectPublishOutput : ServiceOutput
    {
        public ProjectPublishOutput(DirectoryInfo directory)
        {
            Directory = directory;
        }

        public DirectoryInfo Directory { get; }
    }
}
