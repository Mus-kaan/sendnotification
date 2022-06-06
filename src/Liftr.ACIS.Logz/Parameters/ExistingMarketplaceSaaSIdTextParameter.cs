//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;

namespace Microsoft.Liftr.ACIS
{
    public class ExistingMarketplaceSaaSIdTextParameter : AcisSMETextParameter
    {
        public override string Name => "Existing Marketplace SaaS id";

        public override string HelpText => "Existing Marketplace SaaS id";
    }
}