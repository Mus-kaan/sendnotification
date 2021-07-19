//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;

namespace Microsoft.Liftr.ACIS.Confluent.Params
{
    public class ProviderNamespaceParameter : AcisSMETextParameter
    {
        /// <summary>
        /// Enter the text to be shown at UI for Param
        /// </summary>
        public override string Name => "Provider Namespace";

        /// <summary>
        /// Help text for param
        /// </summary>
        public override string HelpText => "Please enter your RP Namespace (e.g. Microsoft.Confluent)";
    }
}