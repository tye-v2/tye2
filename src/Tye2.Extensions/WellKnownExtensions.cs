﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using Tye2.Core;
using Tye2.Extensions.Dapr;
using Tye2.Extensions.Elastic;
using Tye2.Extensions.Seq;
using Tye2.Extensions.Zipkin;

namespace Tye2.Extensions
{
    public static class WellKnownExtensions
    {
        public static IReadOnlyDictionary<string, Extension> Extensions = new Dictionary<string, Extension>(StringComparer.InvariantCultureIgnoreCase)
        {
            { "dapr", new DaprExtension() },
            { "elastic", new ElasticStackExtension() },
            { "seq", new SeqExtension() },
            { "zipkin", new ZipkinExtension() },
        };
    }
}
