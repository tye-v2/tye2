﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Tye2.Core
{
    public sealed class ExternalServiceBuilder : ServiceBuilder
    {
        public ExternalServiceBuilder(string name, ServiceSource source)
            : base(name, source)
        {
        }
    }
}
