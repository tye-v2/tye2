

using System.IO;

namespace Tye2.Core.ConfigModel
{
    internal static class NameInferer
    {
        public static string? InferApplicationName(FileInfo fileInfo)
        {
            if (fileInfo == null)
            {
                return null;
            }

            var extension = fileInfo.Extension;
            if (extension == ".sln" || extension == ".csproj" || extension == ".fsproj")
            {
                return Path.GetFileNameWithoutExtension(fileInfo.Name).ToLowerInvariant();
            }

            return fileInfo.Directory?.Name.ToLowerInvariant();
        }
    }
}
