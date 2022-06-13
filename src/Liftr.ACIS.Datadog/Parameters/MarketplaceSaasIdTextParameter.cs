//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;

namespace Microsoft.Liftr.ACIS.Datadog.Params
{
    public class MarketplaceSaasIdTextParameter : AcisSMETextParameter
    {
        public override string Name => "Marketplace Saas Id";

        public override string HelpText => "Enter New Marketplace SubscriptionId";
    }
}
