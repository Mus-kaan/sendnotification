//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;

namespace Microsoft.Liftr.ACIS
{
    public class MarketplaceResourceIdBoolParameter : AcisSMEBooleanParameter
    {
        public override string Name => "Update Marketplace Resource Id";

        public override string HelpText => "Update Marketplace Resource Id?";
    }
}
