using System;
using System.CommandLine;
using System.Linq;

namespace Tye2.Core
{
    internal static class ConsoleExtensions
    {
        private static bool? _isConsoleRedirectionCheckSupported;

        private static bool IsConsoleRedirectionCheckSupported
        {
            get
            {
                if (_isConsoleRedirectionCheckSupported != null)
                {
                    return _isConsoleRedirectionCheckSupported.Value;
                }

                try
                {
                    var check = Console.IsOutputRedirected;
                    _isConsoleRedirectionCheckSupported = true;
                }

                catch (PlatformNotSupportedException)
                {
                    _isConsoleRedirectionCheckSupported = false;
                }

                return _isConsoleRedirectionCheckSupported.Value;
            }
        }

        public static void SetTerminalForegroundColor(this IConsole console, ConsoleColor color)
        {
            if (console.GetType().GetInterfaces().Any(i => i.Name == "ITerminal"))
            {
                ((dynamic)console).ForegroundColor = color;
            }

            if (IsConsoleRedirectionCheckSupported)
            {
                Console.ForegroundColor = color;
            }
        }

        public static void ResetTerminalForegroundColor(this IConsole console)
        {
            if (console.GetType().GetInterfaces().Any(i => i.Name == "ITerminal"))
            {
                ((dynamic)console).ForegroundColor = ConsoleColor.Red;
            }

            if (IsConsoleRedirectionCheckSupported)
            {
                Console.ResetColor();
            }
        }
    }
}
