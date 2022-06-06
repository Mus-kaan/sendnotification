//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;

namespace Microsoft.Liftr.ACIS.Elastic.Params
{
    public class SubscriptionIdTextParameter : AcisSMETextParameter
    {
        public override string Name => "Marketplace Saas Subscription id";

        public override string HelpText => "Marketplace Subscription id";
    }
}
