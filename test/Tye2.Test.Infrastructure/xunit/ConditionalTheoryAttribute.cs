﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Xunit;
using Xunit.Sdk;

namespace Tye2.Test.Infrastructure.xunit
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    [XunitTestCaseDiscoverer("Microsoft.AspNetCore.Testing." + nameof(ConditionalTheoryDiscoverer), "Microsoft.AspNetCore.Testing")]
    public class ConditionalTheoryAttribute : TheoryAttribute
    {
    }
}
