﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.CommandLine;
using System.Linq;

namespace Tye2
{
    internal static class ConsoleExtensions
    {
        private static bool? isConsoleRedirectionCheckSupported;

        private static bool IsConsoleRedirectionCheckSupported
        {
            get
            {
                if (isConsoleRedirectionCheckSupported == null)
                {
                    try
                    {
                        var check = Console.IsOutputRedirected;
                        isConsoleRedirectionCheckSupported = true;
                    }

                    catch (PlatformNotSupportedException)
                    {
                        isConsoleRedirectionCheckSupported = false;
                    }
                }

                return isConsoleRedirectionCheckSupported.Value;
            }
        }

        public static void SetTerminalForegroundColor(this IConsole console, ConsoleColor color)
        {
            if (console.GetType().GetInterfaces().Any(i => i.Name == "ITerminal"))
            {
                ((dynamic)console).ForegroundColor = color;
            }

            if (IsConsoleRedirectionCheckSupported &&
                !Console.IsOutputRedirected)
            {
                Console.ForegroundColor = color;
            }
            else if (IsConsoleRedirectionCheckSupported)
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

            if (IsConsoleRedirectionCheckSupported &&
                !Console.IsOutputRedirected)
            {
                Console.ResetColor();
            }
            else if (IsConsoleRedirectionCheckSupported)
            {
                Console.ResetColor();
            }
        }
    }
}
