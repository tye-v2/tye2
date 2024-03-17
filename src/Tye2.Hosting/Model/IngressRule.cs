﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Tye2.Hosting.Model
{
    public class IngressRule
    {
        public IngressRule(string? host, string? path, string service, bool preservePath)
        {
            Host = host;
            Path = path;
            PreservePath = preservePath;
            Service = service;
        }

        public string? Host { get; }
        public string? Path { get; }
        public bool PreservePath { get; }
        public string Service { get; }
    }
}
