//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;

namespace Microsoft.Liftr.ACIS
{
    public class SubscriptionIdTextParameter : AcisSMETextParameter
    {
        public override string Name => "Subscription Id";

        public override string HelpText => "Subscription Id";
    }
}