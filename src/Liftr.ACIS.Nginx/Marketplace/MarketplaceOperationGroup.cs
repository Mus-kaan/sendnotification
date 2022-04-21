//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;

namespace Microsoft.Liftr.ACIS.Nginx.Marketplace
{
    /// <summary>
    /// Each Extension contains one more operation groups.
    /// This enables extension owners to group (categorize) operations into meaningful groups for ease of management.
    /// </summary>
    public class MarketplaceOperationGroup : AcisSMEOperationGroup
    {
        public const string MarketplaceOperationGroupName = "Marketplace";

        public override string Name => MarketplaceOperationGroupName;
    }
}
