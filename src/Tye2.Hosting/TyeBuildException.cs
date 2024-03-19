using System;
using System.Runtime.Serialization;

namespace Tye2.Hosting
{
    [Serializable]
    internal class TyeBuildException : Exception
    {
        public TyeBuildException()
        {
        }

        public TyeBuildException(string? message) : base(message)
        {
        }

        public TyeBuildException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected TyeBuildException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
