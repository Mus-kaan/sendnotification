//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;
using System;
using System.Collections.Generic;

namespace Microsoft.Liftr.ACIS.Confluent.Partner
{
    public class FailedRequestWebhookCallOperation : AcisSMEOperation
    {
        /// <summary>
        /// Name of the operation. This is prominently visible from Jarvis. One search an operation by name.
        /// </summary>
        public override string OperationName { get => "Invoke Failed Request Webhook"; }

        /// <summary>
        /// Each operation belongs to an operation group. This is how we associate an operation with operation group.
        /// </summary>
        public override IAcisSMEOperationGroup OperationGroup { get => new PartnerOperationGroup(); }

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
        public override IEnumerable<IAcisSMEParameterRef> Parameters => Array.Empty<IAcisSMEParameterRef>();

        /// <summary>
        /// This is main execute method for the operation.
        /// Name of the method is same as class name after truncating Operation in the end.
        /// for example this class name is FetchInternalMetadata and thus method name is FetchInternalMetadata()
        /// </summary>
        /// <param name="extension"></param>
        /// <param name="updater"></param>
        /// <param name="endpoint"></param>
        /// <returns></returns>
#pragma warning disable CA1822 // Mark members as static
        public IAcisSMEOperationResponse FailedRequestWebhookCall(IAcisServiceManagementExtension extension = null, IAcisSMEOperationProgressUpdater updater = null, IAcisSMEEndpoint endpoint = null)
#pragma warning restore CA1822 // Mark members as static
        {
            var returnMessage = "Mock Webhook call";

#pragma warning disable CA1062 // Validate arguments of public methods
            updater.WriteLine("Finished operation");
#pragma warning restore CA1062 // Validate arguments of public methods
            return AcisSMEOperationResponseExtensions.StandardSuccessResponse(returnMessage);
        }
    }
}
