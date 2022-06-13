//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;

namespace Microsoft.Liftr.ACIS.Nginx.HOBOBilling
{
    /// <summary>
    /// Each Extension contains one more operation groups.
    /// This enables extension owners to group (categorize) operations into meaningful groups for ease of management.
    /// </summary>
    public class HOBOBillingOperationGroup : AcisSMEOperationGroup
    {
        public const string HOBOBillingOperationGroupName = "HOBO Billing";

        public override string Name => HOBOBillingOperationGroupName;
    }
}
