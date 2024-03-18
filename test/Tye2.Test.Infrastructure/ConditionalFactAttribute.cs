// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Xunit;
using Xunit.Sdk;

namespace Tye2.Test.Infrastructure
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    [XunitTestCaseDiscoverer("Tye2.Test.Infrastructure." + nameof(ConditionalFactDiscoverer), "Tye2.Test.Infrastructure")]
    public class ConditionalFactAttribute : FactAttribute
    {
    }
}
