//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.Liftr.ACIS.Contracts;
using Microsoft.Liftr.ACIS.Nginx.Common;
using Microsoft.Liftr.ACIS.Nginx.Parameters;
using Microsoft.WindowsAzure.Wapd.Acis.Contracts;
using System.Collections.Generic;

namespace Microsoft.Liftr.ACIS.Nginx.RPaaS
{
    /// <summary>
    /// Class name is important for Extension operations.
    /// ClassName after truncating Operation word in the end, is treated as operation ID.
    ///
    /// Also we need to implement a method with same name, which works as main execute method for this operation.
    /// There is a way to overwrite and implement some other method as main execute, Refer References in section for details.
    /// </summary>
    public class GetNginxDeploymentOperation : AcisSMEOperation
    {
        public override string OperationName => "Get Nginx Deployment";

        public override IAcisSMEOperationGroup OperationGroup => new RPaaSOperationGroup();

        public override IEnumerable<AcisUserClaim> ClaimsRequired => new[] { AcisSMESecurityGroup.PlatformServiceViewer };

        public override IEnumerable<IAcisSMEParameterRef> Parameters => new[]
            {
                ParamRefFromParam.Get<DeploymentResourceIdTextParameter>(isOptional: false),
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
        /// for example this class name is FetchSaasResourceId and thus method name is FetchSaasResourceId()
        /// </summary>
        /// <param name="deploymentResourceId">Resource Id. This param is picked from Params attribute in the same order</param>
        /// <param name="extension">Management extension</param>
        /// <param name="updater">Operation progress updater</param>
        /// <param name="endpoint">Current end point</param>
        /// <returns></returns>
        public IAcisSMEOperationResponse GetNginxDeployment(string deploymentResourceId, IAcisServiceManagementExtension extension = null, IAcisSMEOperationProgressUpdater updater = null, IAcisSMEEndpoint endpoint = null) => Common.Utilities.CallOperationAsync(ACISOperationTypes.GetNginxDeployment, extension, updater, endpoint, parameters: deploymentResourceId).Result;
    }
}
