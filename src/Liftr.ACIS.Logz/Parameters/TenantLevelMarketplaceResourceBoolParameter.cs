//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;

namespace Microsoft.Liftr.ACIS
{
    public class TenantLevelMarketplaceResourceBoolParameter : AcisSMEBooleanParameter
    {
        public override string Name => "Is Tenant Level Marketplace Resource";

        public override string HelpText => "Is Tenant Level Marketplace Resource?";
    }
}
