using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Tye2.Hosting.Watch.Internal
{
    public class FileSetWatcher : IDisposable
    {
        private readonly FileWatcher _fileWatcher;
        private readonly IFileSet _fileSet;

        public FileSetWatcher(IFileSet fileSet, ILogger logger)
        {
            _fileSet = fileSet;
            _fileWatcher = new FileWatcher(logger);
        }

        public async Task<string> GetChangedFileAsync(CancellationToken cancellationToken, Action startedWatching)
        {
            foreach (var file in _fileSet)
            {
                _fileWatcher.WatchDirectory(Path.GetDirectoryName(file)!);
            }

            var tcs = new TaskCompletionSource<string>();
            cancellationToken.Register(() => tcs.TrySetResult(null!));

            Action<string> callback = path =>
            {
                if (_fileSet.Contains(path))
                {
                    tcs.TrySetResult(path);
                }
            };

            _fileWatcher.OnFileChange += callback;
            startedWatching();
            var changedFile = await tcs.Task;
            _fileWatcher.OnFileChange -= callback;

            return changedFile;
        }


        public Task<string> GetChangedFileAsync(CancellationToken cancellationToken)
        {
            return GetChangedFileAsync(cancellationToken, () => { });
        }

        public void Dispose()
        {
            _fileWatcher.Dispose();
        }
    }
}
