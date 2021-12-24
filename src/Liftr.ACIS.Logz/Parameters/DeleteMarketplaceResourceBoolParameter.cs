//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;

namespace Microsoft.Liftr.ACIS
{
    public class DeleteMarketplaceResourceBoolParameter : AcisSMEBooleanParameter
    {
        public override string Name => "Delete Marketplace Resource";

        public override string HelpText => "Delete Marketplace Resource?";
    }
}
