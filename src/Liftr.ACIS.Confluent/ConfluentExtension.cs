//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;
using System;
using System.Linq;

namespace Microsoft.Liftr.ACIS.Confluent
{
    /// <summary>
    /// Extension is the Root of tree beneath which all geneva actions are.
    /// https://genevamondocs.azurewebsites.net/actions/Quickstart/developFirstGAExtensionCSharp.html
    /// </summary>
    public class ConfluentExtension : AcisServiceManagementExtension
    {
        // A convenience in this sample for general use
        private readonly string _serviceNameConst = "Liftr Confluent";

        #region Required for Extension infrastructure

        /// <summary>
        /// Extension name
        /// Uniquely identifies the Extension
        /// </summary>
        public override string ServiceName { get => _serviceNameConst; }

        /// <summary>
        /// Extension Version
        /// </summary>
        public override string ExtensionVersion
        {
            get { return "1.0"; }
        }

        /// <summary>
        /// Always called when extension is loaded, allows dynamic creation of
        ///  endpoints and general initialization
        /// </summary>
        /// <returns></returns>
        public override bool OnLoad()
        {
            Logger.LogVerbose($"Just loaded {ServiceName}");
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

            // Report on the core information for the extension
            Logger.LogVerbose($"Extension {endpoint.ContainingExtension.ServiceName} creating endpoint {endpoint.Name}");
            Logger.LogVerbose($".. claims required are {string.Join("|", endpoint.ClaimsRequired.Select(claim => claim.Name))}");
            Logger.LogVerbose($".. operations provided are {string.Join("|", endpoint.Operations.Select(op => op.ToString()))}");

            // Report on the configuration contained in the endpoint - the Geneva Actions infrastructure doesn't rely on any of this
            //  configuration it's purely for the extension's use
            Logger.LogVerbose($".. configuration defines environment as {endpoint.Configuration.GetConfigurationValue("env")}");

            return true;
        }

        #endregion
    }
}
