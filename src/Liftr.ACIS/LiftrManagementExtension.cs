//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.Liftr.ACIS.Logging;
using Microsoft.Liftr.Logging.StaticLogger;
using Microsoft.WindowsAzure.Wapd.Acis.Contracts;
using System;
using System.Linq;

namespace Microsoft.Liftr.ACIS
{
    public class LiftrManagementExtension : AcisServiceManagementExtension
    {
        public const string ServiceNameConst = "Liftr";

        public override string ServiceName => ServiceNameConst;

        public override string ExtensionVersion => "1.0";

        /// <summary>
        /// Always called when extension is loaded, allows dynamic creation of
        ///  endpoints and general initialization
        /// </summary>
        public override bool OnLoad()
        {
            var ikey = "eb4a9680-a4b6-43ea-8183-52348e4370e5"; // 'liftr-acis-non-prod-wus2-ai' in 'Liftr - TEST'
            StaticLiftrLogger.Initilize(ikey);
            var logger = new AcisLogger(this);
            logger.LogInfo($"Just loaded {nameof(LiftrManagementExtension)}");
            return true;
        }

        /// <summary>
        /// Each endpoint that is created is initialized and then this method is called
        /// providing that endpoint.  Unlike our other extension points, you can't extend
        /// an endpoint - it is populated only from your configuration file.
        /// </summary>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        public override bool OnEndpointCreate(IAcisSMEEndpoint endpoint)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }

            var logger = new AcisLogger(this, endpoint: endpoint);

            // Report on the core information for the extension
            logger.LogInfo($"Extension {endpoint.ContainingExtension.ServiceName} creating endpoint {endpoint.Name}");
            logger.LogInfo($".. claims required are {string.Join("|", endpoint.ClaimsRequired.Select(claim => claim.Name))}");
            logger.LogInfo($".. operations provided are {string.Join("|", endpoint.Operations.Select(op => op.ToString()))}");

            // Report on the configuration contained in the endpoint - the Geneva Actions infrastructure doesn't rely on any of this
            //  configuration it's purely for the extension's use
            logger.LogInfo($".. configuration defines environment as {endpoint.Configuration.GetConfigurationValue("env")}");

            return true;
        }
    }
}
