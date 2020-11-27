//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.Liftr.ACIS.Common;
using Microsoft.Liftr.ACIS.Logging;
using Microsoft.Liftr.ACIS.Relay;
using Microsoft.Liftr.Contracts;
using Microsoft.WindowsAzure.Wapd.Acis.Contracts;
using System;
using System.Threading.Tasks;

namespace Microsoft.Liftr.ACIS.Confluent.Common
{
    public static class Utilities
    {
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
            logger.LogInfo($"Secret Identifiers: {endpoint.Secrets.Identifiers.ToJson()}");
            var secret = await endpoint.Secrets.GetSecretAsync(Constants.ACISStorConn);

            ACISOperationStorageOptions options = new ACISOperationStorageOptions()
            {
                StorageAccountConnectionString = secret,
            };

            ACISWorkCoordinator coordinator = new ACISWorkCoordinator(options, new SystemTimeSource(), logger, timeout: TimeSpan.FromSeconds(60));
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
            logger.LogInfo($"Secret Identifiers: {endpoint.Secrets.Identifiers.ToJson()}");
            var secret = await endpoint.Secrets.GetSecretAsync(Constants.ACISStorConn);

            return AcisSMEOperationResponseExtensions.StandardSuccessResponse($"Not enabled yet for {operationName}");
        }

        /// <summary>
        /// Form param using resource id and tenant id
        /// </summary>
        /// <param name="resourceId"></param>
        /// <param name="tenantId"></param>
        /// <returns></returns>
        public static string CombineResourceIdTenantId(string resourceId, string tenantId) => $"{resourceId}~GA~{tenantId}";
    }
}
