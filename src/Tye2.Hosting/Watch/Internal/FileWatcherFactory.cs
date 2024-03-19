

namespace Tye2.Hosting.Watch.Internal
{
    public static class FileWatcherFactory
    {
        public static IFileSystemWatcher CreateWatcher(string watchedDirectory)
              => new DotnetFileWatcher(watchedDirectory);
    }
}
