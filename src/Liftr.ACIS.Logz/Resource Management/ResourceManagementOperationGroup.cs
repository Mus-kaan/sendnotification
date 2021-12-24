//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;

namespace Microsoft.Liftr.ACIS
{
    /// <summary>
    /// Each Extension contains one more operation groups.
    /// This enables extension owners to group (categorize) operations into meaningful groups for ease of management.
    /// </summary>
    public class ResourceManagementOperationGroup : AcisSMEOperationGroup
    {
        public const string ResourceManagementOperationGroupName = "Resource Management";

        public override string Name => ResourceManagementOperationGroupName;
    }
}
