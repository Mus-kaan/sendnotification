//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.Liftr.ACIS.Logging;
using Microsoft.Liftr.DataSource.Mongo.MonitoringSvc;
using Microsoft.Liftr.Management;
using Microsoft.WindowsAzure.Wapd.Acis.Contracts;
using System;
using System.Collections.Generic;

namespace Microsoft.Liftr.ACIS
{
    /// <summary>
    /// Class name is important for Extension operations.
    /// ClassName after truncating Operation word in the end, is treated as operation ID.
    ///
    /// Also we need to implement a method with same name, which works as main execute method for this operation.
    /// There is a way to overwrite and implement some other method as main execute, Refer References in section for details.
    /// </summary>
    public class ListEventhubOperation : AcisSMEOperation
    {
        public override string OperationName => "ListEventhub";

        public override IAcisSMEOperationGroup OperationGroup => new LogForwarderOperationGroup();

        public override IEnumerable<AcisUserClaim> ClaimsRequired => new[] { AcisSMESecurityGroup.PlatformServiceViewer };

        public override IEnumerable<IAcisSMEParameterRef> Parameters => Array.Empty<IAcisSMEParameterRef>();

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
        public IAcisSMEOperationResponse ListEventhub(IAcisServiceManagementExtension extension = null, IAcisSMEOperationProgressUpdater updater = null, IAcisSMEEndpoint endpoint = null)
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
            var ops = logger.StartTimedOperation(nameof(ListEventhub));
            try
            {
                // TODO: rotate this secondary key
                var connectionString = "mongodb://dd-dev-data20200502-wus2-db:vnIjs5DweP6ufjIsdYQUaXhVtag6Ku2KWtTlX9cbPZO553Cua0qIB3GvKI4wMEO31LqOOs9JR4yEYHSXfcodbw==@dd-dev-data20200502-wus2-db.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";
                MonitoringSvcMongoOptions options = new MonitoringSvcMongoOptions()
                {
                    ConnectionString = connectionString,
                    DatabaseName = "monitoringsvc-metadata",
                };

                var evhManagement = new EventHubManagement(options, logger);

                var evhList = evhManagement.ListAsync().Result;

                return AcisSMEOperationResponseExtensions.StandardSuccessResponse(evhList);
            }
            catch (Exception ex)
            {
                ops.FailOperation(ex.Message);
                logger.LogError(ex, $"{nameof(ListEventhub)} failed");
                return AcisSMEOperationResponseExtensions.StandardErrorResponse(ex);
            }
        }
    }
}
