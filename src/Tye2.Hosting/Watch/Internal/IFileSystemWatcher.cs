using System;

namespace Tye2.Hosting.Watch.Internal
{
    public interface IFileSystemWatcher : IDisposable
    {
        event EventHandler<string> OnFileChange;

        event EventHandler<Exception> OnError;

        string BasePath { get; }

        bool EnableRaisingEvents { get; set; }
    }
}
