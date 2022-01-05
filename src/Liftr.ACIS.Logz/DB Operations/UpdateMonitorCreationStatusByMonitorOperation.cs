//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.Liftr.ACIS.Common;
using Microsoft.Liftr.ACIS.Contracts;
using Microsoft.Liftr.ACIS.Logging;
using Microsoft.Liftr.ACIS.Relay;
using Microsoft.Liftr.Contracts;
using Microsoft.WindowsAzure.Wapd.Acis.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.Liftr.ACIS.Logz
{
    /// <summary>
    /// Class name is important for Extension operations.
    /// ClassName after truncating Operation word in the end, is treated as operation ID.
    ///
    /// Also we need to implement a method with same name, which works as main execute method for this operation.
    /// There is a way to overwrite and implement some other method as main execute, Refer References in section for details.
    /// </summary>
    public class UpdateMonitorCreationStatusByMonitorOperation : AcisSMEOperation
    {
        public override string OperationName => "UpdateMonitorCreationStatusByMonitor";

        public override IAcisSMEOperationGroup OperationGroup => new DBOperationGroup();

        public override IEnumerable<AcisUserClaim> ClaimsRequired => new[] { AcisSMESecurityGroup.PlatformServiceViewer };

        public override IEnumerable<IAcisSMEParameterRef> Parameters => new[]
            {
                ParamRefFromParam.Get<MonitorResourceIdTextParameter>(isOptional: false),
                ParamRefFromParam.Get<MonitorCreationStatusObjectTextParameter>(isOptional: false),
                ParamRefFromParam.Get<APITokenBoolParameter>(isOptional: false),
                ParamRefFromParam.Get<ShippingTokenBoolParameter>(isOptional: false),
                ParamRefFromParam.Get<MarketplaceResourceIdBoolParameter>(isOptional: false),
            };

        /// <summary>
        /// Data Access Levels provide information to compliance about what sort of data your operation is interacting with.
        /// By default, all Data Access Levels are set to DataAccessLevel.None. The framework enforces that at least one of them
        /// must be set to a higher level (DataAccessLevel.ReadOnly or DataAccessLevel.ReadWrite).Additionally, there is claim/data-access-level
        /// verification: if you indicate your operation interacts with customer data, your claims cannot be* PlatformService* claims.
        /// If you indicate that your operation is a read-write operation, your claims cannot be* Viewer claims.
        /// </summary>
        public override DataAccessLevel SystemMetadata
        {
            get
            {
                return DataAccessLevel.ReadOnly;
            }
        }

        /// <summary>
        /// This is main execute method for the operation.
        /// Name of the method is same as class name after truncating Operation in the end.
        /// </summary>
        public IAcisSMEOperationResponse UpdateMonitorCreationStatusByMonitor(string monitorId, string monitorCreationStatusObject, bool IsUpdateAPIToken, bool IsUpdateShippingToken, bool IsUpdateMarketplaceResourceId, IAcisServiceManagementExtension extension = null, IAcisSMEOperationProgressUpdater updater = null, IAcisSMEEndpoint endpoint = null)
        {
            return UpdateMonitorCreationStatusByMonitorAsync(monitorId, monitorCreationStatusObject, IsUpdateAPIToken, IsUpdateShippingToken, IsUpdateMarketplaceResourceId, extension, updater, endpoint).Result;
        }

        private async Task<IAcisSMEOperationResponse> UpdateMonitorCreationStatusByMonitorAsync(string monitorId, string monitorCreationStatusObject, bool IsUpdateAPIToken, bool IsUpdateShippingToken, bool IsUpdateMarketplaceResourceId, IAcisServiceManagementExtension extension = null, IAcisSMEOperationProgressUpdater updater = null, IAcisSMEEndpoint endpoint = null)
        {
            if (extension == null)
            {
                throw new ArgumentNullException(nameof(extension));
            }

            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }

            if (updater == null)
            {
                throw new ArgumentNullException(nameof(updater));
            }

            var logger = new AcisLogger(extension, updater, endpoint);

            logger.LogInfo("Loading ACIS storage account connection string from key vault ...");
            logger.LogInfo($"Secret Identifiers: {endpoint.Secrets.Identifiers.ToJson()}");
            var secret = await endpoint.Secrets.GetSecretAsync("ACISStorConn");

            ACISOperationStorageOptions options = new ACISOperationStorageOptions()
            {
                StorageAccountConnectionString = secret,
            };

            if (endpoint.Name.Equals(Constants.LocalEndpointName, StringComparison.OrdinalIgnoreCase))
            {
                options.OperationNotificationQueueName = Constants.OperationNotificationQueueNameLocal;
            }

            UpdateMonitorCreationStatusMessage message = new UpdateMonitorCreationStatusMessage()
            {
                MonitorId = monitorId,
                MonitorCreationStatusObject = monitorCreationStatusObject,
                IsUpdateAPIToken = IsUpdateAPIToken,
                IsUpdateShippingToken = IsUpdateShippingToken,
                IsUpdateMarketplaceResourceId = IsUpdateMarketplaceResourceId,
            };

            ACISWorkCoordinator coordinator = new ACISWorkCoordinator(options, new SystemTimeSource(), logger, timeout: TimeSpan.FromSeconds(120));
            var result = await coordinator.StartWorkAsync(nameof(UpdateMonitorCreationStatusByMonitor), parameters: message.ToJson());
            if (result.Succeeded)
            {
                return AcisSMEOperationResponseExtensions.StandardSuccessResponse(result.Result);
            }
            else
            {
                return AcisSMEOperationResponseExtensions.SpecificErrorResponse(result.Result);
            }
        }
    }
}
