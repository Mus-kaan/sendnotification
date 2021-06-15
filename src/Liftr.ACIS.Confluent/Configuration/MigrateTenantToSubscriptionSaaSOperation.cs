//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.Liftr.ACIS.Confluent.Common;
using Microsoft.Liftr.ACIS.Confluent.Params;
using Microsoft.WindowsAzure.Wapd.Acis.Contracts;
using System.Collections.Generic;

namespace Microsoft.Liftr.ACIS.Confluent.Configuration
{
    public class MigrateTenantToSubscriptionSaaSOperation : AcisSMEOperation
    {
        /// <summary>
        /// Name of the operation. This is prominently visible from Jarvis. One search an operation by name.
        /// </summary>
        public override string OperationName { get => "Migrate SaaS Resource from Tenant to Subscription Level"; }

        /// <summary>
        /// Each operation belongs to an operation group. This is how we associate an operation with operation group.
        /// </summary>
        public override IAcisSMEOperationGroup OperationGroup { get => new ConfigurationOperationGroup(); }

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
        public override DataAccessLevel SystemMetadata
        {
            get
            {
                return DataAccessLevel.ReadOnly;
            }
        }

        /// <summary>
        /// This controls all input parameters to an operation. For current operation we do not have any input parameters.
        /// Look at examples mentioned in the end of this tutorial to see how different parameters can be used.
        /// </summary>
        public override IEnumerable<IAcisSMEParameterRef> Parameters
        {
            get
            {
                return new IAcisSMEParameterRef[]
                {
                    ParamRefFromParam.Get<SubscriptionIdParameter>(),
                    ParamRefFromParam.Get<ResourceGroupParameter>(),
                    ParamRefFromParam.Get<SaaSResourceNameParameter>(),
                    ParamRefFromParam.Get<MarketplaceSubscriptionIdParameter>(),
                    ParamRefFromParam.Get<TenantIdParameter>(),
                    ParamRefFromParam.Get<PrincipalNameParameter>(),
                    ParamRefFromParam.Get<ObjectIdParameter>(),
                };
            }
        }

        /// <summary>
        /// This is main execute method for the operation.
        /// Name of the method is same as class name after truncating Operation in the end.
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="resourceGroup"></param>
        /// <param name="saasResourceName"></param>
        /// <param name="saasSubscriptionId"></param>
        /// <param name="tenantId"></param>
        /// <param name="principalName"></param>
        /// <param name="objectId"></param>
        /// <param name="extension"></param>
        /// <param name="updater"></param>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        public IAcisSMEOperationResponse MigrateTenantToSubscriptionSaaS(string subscriptionId, string resourceGroup, string saasResourceName, string saasSubscriptionId, string tenantId, string principalName, string objectId, IAcisServiceManagementExtension extension = null, IAcisSMEOperationProgressUpdater updater = null, IAcisSMEEndpoint endpoint = null) => Common.Utilities.CallOpertionAsync("MigrateTenantToSubscriptionSaaS", extension, updater, endpoint, parameters: Common.Utilities.ConcatParams(subscriptionId, resourceGroup, saasResourceName, saasSubscriptionId, tenantId, principalName, objectId)).Result;
    }
}
