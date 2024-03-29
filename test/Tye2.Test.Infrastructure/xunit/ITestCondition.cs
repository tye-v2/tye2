﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Tye2.Test.Infrastructure.xunit
{
    public interface ITestCondition
    {
        bool IsMet { get; }

        string SkipReason { get; }
    }
}
