//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.Liftr.ACIS.Common;
using Microsoft.Liftr.ACIS.Logging;
using Microsoft.Liftr.ACIS.Relay;
using Microsoft.Liftr.Contracts;
using Microsoft.WindowsAzure.Wapd.Acis.Contracts;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Liftr.ACIS.Datadog.Common
{
    public static class Utilities
    {
        public const string ValueSeparator = "~GA~";

        /// <summary>
        /// Call ACIS backend
        /// </summary>
        /// <param name="operationName">Operation Name</param>
        /// <param name="parameters">Parameters to be passed with Operation name</param>
        /// <param name="extension">Acis service management extension</param>
        /// <param name="updater">Progress updater</param>
        /// <param name="endpoint">ACIS endpoint</param>
        /// <param name="operationId">Opertion id. Its optional</param>
        /// <returns></returns>
        public static async Task<IAcisSMEOperationResponse> CallOpertionAsync(
            string operationName,
            IAcisServiceManagementExtension extension = null,
            IAcisSMEOperationProgressUpdater updater = null,
            IAcisSMEEndpoint endpoint = null,
            string parameters = null,
            string operationId = null)
        {
            var logger = new AcisLogger(extension, updater, endpoint);

            logger.LogInfo("Loading ACIS storage account connection string from key vault ...");
#pragma warning disable CA1062 // Validate arguments of public methods
            logger.LogInfo($"Secret Identifiers: {endpoint.Secrets.Identifiers.ToJson()}");
#pragma warning restore CA1062 // Validate arguments of public methods
            var secret = await endpoint.Secrets.GetSecretAsync(Constants.ACISStorConn);

            ACISOperationStorageOptions options = new ACISOperationStorageOptions()
            {
                StorageAccountConnectionString = secret,
            };

            ACISWorkCoordinator coordinator = new ACISWorkCoordinator(options, new SystemTimeSource(), logger, timeout: TimeSpan.FromSeconds(300));
            var result = await coordinator.StartWorkAsync(operationName, parameters: parameters);
            if (result.Succeeded)
            {
                return AcisSMEOperationResponseExtensions.StandardSuccessResponse(result.Result);
            }
            else
            {
                return AcisSMEOperationResponseExtensions.SpecificErrorResponse(result.Result);
            }
        }

        /// <summary>
        /// Call ACIS backend
        /// </summary>
        /// <param name="operationName">Operation Name</param>
        /// <param name="extension">Acis service management extension</param>
        /// <param name="updater">Progress updater</param>
        /// <param name="endpoint">ACIS endpoint</param>
        /// <returns></returns>
        public static async Task<IAcisSMEOperationResponse> CallOpertionAsync(
            string operationName,
            IAcisServiceManagementExtension extension = null,
            IAcisSMEOperationProgressUpdater updater = null,
            IAcisSMEEndpoint endpoint = null)
        {
            var logger = new AcisLogger(extension, updater, endpoint);

            logger.LogInfo("Loading ACIS storage account connection string from key vault ...");
#pragma warning disable CA1062 // Validate arguments of public methods
            logger.LogInfo($"Secret Identifiers: {endpoint.Secrets.Identifiers.ToJson()}");
#pragma warning restore CA1062 // Validate arguments of public methods
            var secret = await endpoint.Secrets.GetSecretAsync(Constants.ACISStorConn);

            return AcisSMEOperationResponseExtensions.StandardSuccessResponse($"Not enabled yet for {operationName}");
        }

        /// <summary>
        /// Form param using resource id and tenant id
        /// </summary>
        /// <param name="resourceId"></param>
        /// <param name="tenantId"></param>
        /// <returns></returns>
        public static string CombineResourceIdTenantId(string resourceId, string tenantId) => $"{resourceId}{ValueSeparator}{tenantId}";

        /// <summary>
        /// Combine values
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static string ConcatParams(params string[] values)
        {
            if (!values.Any())
            {
                return string.Empty;
            }

            var builder = new StringBuilder();
            builder.Append(values[0]);
            for (int i = 1; i < values.Length; i++)
            {
                builder.Append(ValueSeparator).Append(values[i]);
            }

            return builder.ToString();
        }
    }
}
