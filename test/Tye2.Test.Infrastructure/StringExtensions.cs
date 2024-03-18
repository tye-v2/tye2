using System;

namespace Tye2.Test.Infrastructure
{
    public static class StringExtensions
    {
        public static string NormalizeNewLines(this string value)
        {
            return value
                .Replace("\r\n", "\n")
                .Replace("\n", Environment.NewLine);
        }
    }
}
