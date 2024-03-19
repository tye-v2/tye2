using System;
using System.IO;
using YamlDotNet.Core;

namespace Tye2.Core.Serialization
{
    public class TyeYamlException : Exception
    {
        public TyeYamlException(string message)
            : base(message)
        {
        }

        public TyeYamlException(Mark start, string message)
            : this(start, message, null)
        {
        }

        public TyeYamlException(Mark start, string message, Exception? innerException)
            : base($"Error parsing YAML: ({start.Line}, {start.Column}): {message}", innerException)
        {
        }

        public TyeYamlException(Mark start, string message, Exception? innerException, FileInfo fileInfo)
            : base($"Error parsing '{fileInfo.Name}': ({start.Line}, {start.Column}): {message}", innerException)
        {
        }

        public TyeYamlException(string message, Exception? inner)
            : base(message, inner)
        {
        }
    }
}
