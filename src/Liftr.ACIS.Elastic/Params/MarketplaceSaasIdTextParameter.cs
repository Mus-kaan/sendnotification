//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;

namespace Microsoft.Liftr.ACIS.Elastic.Params
{
    public class MarketplaceSaasIdTextParameter : AcisSMETextParameter
    {
        public override string Name => "Marketplace Saas id";

        public override string HelpText => "Marketplace Subscription id";
    }
}
