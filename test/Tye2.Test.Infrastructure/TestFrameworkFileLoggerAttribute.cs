﻿
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Tye2.Test.Infrastructure
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
    public class TestFrameworkFileLoggerAttribute : TestOutputDirectoryAttribute
    {
        public TestFrameworkFileLoggerAttribute(string preserveExistingLogsInOutput, string tfm, string baseDirectory = null)
            : base(preserveExistingLogsInOutput, tfm, baseDirectory)
        {
        }
    }
}
