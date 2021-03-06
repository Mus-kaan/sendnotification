//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.Liftr.ACIS.Common;
using Microsoft.Liftr.ACIS.Datadog.Params;
using Microsoft.Liftr.ACIS.Logging;
using Microsoft.Liftr.ACIS.Relay;
using Microsoft.Liftr.Contracts;
using Microsoft.WindowsAzure.Wapd.Acis.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Liftr.ACIS.Datadog
{
    public class UpdateMarketplaceEntitiesOperation : AcisSMEOperation
    {
        /// <summary>
        /// Name of the operation. This is prominently visible from Jarvis. One search an operation by name.
        /// </summary>
        public override string OperationName { get => "UpdateMarketplaceEntities"; }

        /// <summary>
        /// Each operation belongs to an operation group. This is how we associate an operation with operation group.
        /// </summary>
        public override IAcisSMEOperationGroup OperationGroup { get => new MarketplaceOperationGroup(); }

        /// <summary>
        /// These are the claims required to run this operation.
        /// As this is a test operation everybody who has PlatformServiceViewer claim can run this operation. That is everybody inside @microsoft.com
        /// </summary>
        public override IEnumerable<AcisUserClaim> ClaimsRequired
        {
            get
            {
                return new[]
                {
                    AcisSMESecurityGroup.PlatformServiceViewer,
                };
            }
        }

        /// <summary>
        /// Data Access Levels provide information to compliance about what sort of data your operation is interacting with.
        /// By default, all Data Access Levels are set to DataAccessLevel.None. The framework enforces that at least one of them
        /// must be set to a higher level (DataAccessLevel.ReadOnly or DataAccessLevel.ReadWrite).Additionally, there is claim/data-access-level
        /// verification: if you indicate your operation interacts with customer data, your claims cannot be* PlatformService* claims.
        /// If you indicate that your operation is a read-write operation, your claims cannot be* Viewer claims.
        /// </summary>
        public override DataAccessLevel SystemMetadata => DataAccessLevel.ReadOnly;

        /// <summary>
        /// This controls all input parameters to an operation. For current operation we do not have any input parameters.
        /// Look at examples mentioned in the end of this tutorial to see how different parameters can be used.
        /// </summary>
        public override IEnumerable<IAcisSMEParameterRef> Parameters => new[]
            {
                ParamRefFromParam.Get<SubscriptionIdTextParameter>(isOptional: false),
                ParamRefFromParam.Get<MarketplaceSaasIdTextParameter>(isOptional: false),
                ParamRefFromParam.Get<MonitorResourceIdTextParameter>(isOptional: false),
            };

        /// <summary>
        /// This is main execute method for the operation.
        /// Name of the method is same as class name after truncating Operation in the end.
        /// </summary>
        public IAcisSMEOperationResponse UpdateMarketplaceEntities(string oldMarketplaceSaaSId, string marketplaceSaasId, string dataogResourceId, IAcisServiceManagementExtension extension = null, IAcisSMEOperationProgressUpdater updater = null, IAcisSMEEndpoint endpoint = null)
        {
            return UpdateMarketplaceEntitiesAsync(oldMarketplaceSaaSId, marketplaceSaasId, dataogResourceId, extension, updater, endpoint).Result;
        }

        /// <summary>
        /// This is main execute method for the operation.
        /// Name of the method is same as class name after truncating Operation in the end.
        /// for example this class name is GetMonitorResourceOperation and thus method name is Greetings()
        /// </summary>
        /// <param name="oldMarketplaceSaaSId"></param>
        /// <param name="marketplaceSaasId"></param>
        /// <param name="datadogResourceId"></param>
        /// <param name="extension"></param>
        /// <param name="updater"></param>
        /// <param name="endpoint"></param>
        /// <returns></returns>
#pragma warning disable CA1822 // Mark members as static
        public async Task<IAcisSMEOperationResponse> UpdateMarketplaceEntitiesAsync(string oldMarketplaceSaaSId, string marketplaceSaasId, string datadogResourceId, IAcisServiceManagementExtension extension = null, IAcisSMEOperationProgressUpdater updater = null, IAcisSMEEndpoint endpoint = null)
#pragma warning restore CA1822 // Mark members as static
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

            if (marketplaceSaasId == null)
            {
                throw new ArgumentNullException(nameof(marketplaceSaasId));
            }

            var logger = new AcisLogger(extension, updater, endpoint);

            logger.LogInfo("Loading ACIS storage account connection string from key vault ...");
            logger.LogInfo($"Secret Identifiers: {endpoint.Secrets.Identifiers.ToJson()}");
            var secret = await endpoint.Secrets.GetSecretAsync("ACISStorConn");

            ACISOperationStorageOptions options = new ACISOperationStorageOptions()
            {
                StorageAccountConnectionString = secret,
            };

            ACISWorkCoordinator coordinator = new ACISWorkCoordinator(options, new SystemTimeSource(), logger, timeout: TimeSpan.FromSeconds(60));
            var result = await coordinator.StartWorkAsync(nameof(UpdateMarketplaceEntities), parameters: ConcatParams(oldMarketplaceSaaSId, marketplaceSaasId, datadogResourceId));
            if (result.Succeeded)
            {
                return AcisSMEOperationResponseExtensions.StandardSuccessResponse(result.Result);
            }
            else
            {
                return AcisSMEOperationResponseExtensions.SpecificErrorResponse(result.Result);
            }
        }

        private static string ConcatParams(params string[] values)
        {
            if (!values.Any())
            {
                return string.Empty;
            }

            var builder = new StringBuilder();
            builder.Append(values[0]);
            for (int i = 1; i < values.Length; i++)
            {
                builder.Append("~GA~").Append(values[i]);
            }

            return builder.ToString();
        }
    }
}
