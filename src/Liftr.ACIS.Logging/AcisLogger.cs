//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.Liftr.Logging;
using Microsoft.Liftr.Logging.StaticLogger;
using Microsoft.WindowsAzure.Wapd.Acis.Contracts;
using System;

namespace Microsoft.Liftr.ACIS.Logging
{
    public class AcisLogger : IAcisLogger
    {
        private readonly IAcisServiceManagementExtension _extension;
        private readonly IAcisSMEOperationProgressUpdater _updater;
        private readonly IAcisSMEEndpoint _endpoint;

        public AcisLogger(IAcisServiceManagementExtension extension, IAcisSMEOperationProgressUpdater updater = null, IAcisSMEEndpoint endpoint = null)
        {
            _extension = extension ?? throw new ArgumentNullException(nameof(extension));
            _updater = updater;
            _endpoint = endpoint;
            Logger = StaticLiftrLogger.Logger;
        }

        public Serilog.ILogger Logger { get; }

        public ITimedOperation StartTimedOperation(
           string operationName,
           string operationId = null,
           bool generateMetrics = false,
           bool newCorrelationId = false,
           bool skipAppInsights = false)
        {
            return Logger.StartTimedOperation(operationName, operationId, generateMetrics, newCorrelationId, skipAppInsights);
        }

        public void LogError(string message)
        {
            Logger.Error(message);
            _extension.Logger.LogError(message);
            _updater?.WriteLine($"ERROR: {message}");
        }

        public void LogError(Exception exception, string message)
        {
            Logger.Error(exception, message);
            _extension.Logger.LogError(exception, message);
            _updater?.WriteLine($"ERROR: {message}. Exception: {exception}");
        }

        public void LogWarning(string message)
        {
            Logger.Warning(message);
            _extension.Logger.LogWarning(message);
            _updater?.WriteLine($"WARN: {message}");
        }

        public void LogInfo(string message)
        {
            Logger.Information(message);
            _extension.Logger.LogInfo(message);
            _updater?.WriteLine(message);
        }

        public void LogVerbose(string message)
        {
            Logger.Verbose(message);
            _extension.Logger.LogVerbose(message);
        }
    }
}
