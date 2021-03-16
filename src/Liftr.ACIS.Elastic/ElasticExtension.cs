//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.Liftr.ACIS.Logging;
using Microsoft.Liftr.Logging.StaticLogger;
using Microsoft.WindowsAzure.Wapd.Acis.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Microsoft.Liftr.ACIS.Elastic
{
    public class ElasticExtension : AcisServiceManagementExtension
    {
        private string _serviceNameConst = "Elastic";

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
            get { return GetVersion(); }
        }

        /// <summary>
        /// Always called when extension is loaded, allows dynamic creation of
        ///  endpoints and general initialization
        /// </summary>
        /// <returns></returns>
        public override bool OnLoad()
        {
            var ikey = "eb4a9680-a4b6-43ea-8183-52348e4370e5"; // 'liftr-acis-non-prod-wus2-ai' in 'Liftr - TEST'
            StaticLiftrLogger.Initilize(ikey);
            var logger = new AcisLogger(this);
            logger.LogInfo($"Just loaded {nameof(ElasticExtension)}");
            SetupAssemblyRedirection();
            LoadAssembly(logger);
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
            Logger.LogVerbose(string.Format("Extension {0} creating endpoint {1}", endpoint.ContainingExtension.ServiceName, endpoint.Name));
            Logger.LogVerbose(string.Format(".. claims required are {0}", string.Join("|", endpoint.ClaimsRequired.Select(claim => claim.Name))));
            Logger.LogVerbose(string.Format(".. operations provided are {0}", string.Join("|", endpoint.Operations.Select(op => op.ToString()))));

            // Report on the configuration contained in the endpoint - the Geneva Actions infrastructure doesn't rely on any of this
            //  configuration it's purely for the extension's use
            Logger.LogVerbose(string.Format(".. configuration defines environment as {0}", endpoint.Configuration.GetConfigurationValue("env")));

            return true;
        }

        #endregion

        private static string GetVersion()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var assemblyProductVersion = FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion;
            return assemblyProductVersion;
        }

        private static void SetupAssemblyRedirection()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, e) =>
            {
                string currentFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                AssemblyName requestedName = new AssemblyName(e.Name);
                if (s_redirectDllList.Contains(requestedName.Name))
                {
                    var resolvedAssembly = Assembly.LoadFrom(Path.Combine(currentFolder, requestedName.Name + ".dll"));

                    // Be careful of the below if condition. If you are using an older version of the dll from our dll in your package, it will load our newer version.
                    if (resolvedAssembly.GetName().Version < requestedName.Version)
                    {
                        return null;
                    }

                    return resolvedAssembly;
                }
                else
                {
                    return null;
                }
            };
        }

        private static void LoadAssembly(AcisLogger logger)
        {
            // We need to do this because Actions runtime is using old version of the bellow
            // dll, and it causes the problem
            var assemblyLocation = Assembly.GetExecutingAssembly().Location;
            var dir = Path.GetDirectoryName(assemblyLocation);

            foreach (var dll in s_redirectDllList)
            {
                var assembly = Assembly.LoadFrom(Path.Combine(dir, $"{dll}.dll"));
                AppDomain.CurrentDomain.Load(assembly.GetName());
            }
        }

        private static readonly HashSet<string> s_redirectDllList = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "System.Runtime.InteropServices",
            "System.Runtime.InteropServices.RuntimeInformation",
            "System.Security.Cryptography.Algorithms",
            "System.Security.Cryptography.Csp",
            "System.Security.Cryptography.Encoding",
            "System.Security.Cryptography.Primitives",
            "System.Security.Cryptography.X509Certificates",
        };
    }
}
