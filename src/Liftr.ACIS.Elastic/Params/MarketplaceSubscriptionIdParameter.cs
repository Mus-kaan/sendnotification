//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;

namespace Microsoft.Liftr.ACIS.Elastic.Params
{
    public class MarketplaceSubscriptionIdParameter : AcisSMETextParameter
    {
        /// <summary>
        /// Enter the text to be shown at UI for Param
        /// </summary>
        public override string Name => "Marketplace SaaS Subscription Id";

        /// <summary>
        /// Help text for param
        /// </summary>
        public override string HelpText => "Please enter valid tenant level SaaS resource subscription Id";
    }
}
