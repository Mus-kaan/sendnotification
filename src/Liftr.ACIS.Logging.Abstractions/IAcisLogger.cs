//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using System;

namespace Microsoft.Liftr.ACIS.Logging
{
    public interface IAcisLogger
    {
        Serilog.ILogger Logger { get; }

        void LogError(string message);

        void LogError(Exception exception, string message);

        void LogInfo(string message);

        void LogVerbose(string message);

        void LogWarning(string message);
    }
}
