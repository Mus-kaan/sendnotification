//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;

namespace Microsoft.Liftr.ACIS.Nginx.Partner
{
    /// <summary>
    /// Each Extension contains one more operation groups.
    /// This enables extension owners to group (categorize) operations into meaningful groups for ease of management.
    /// https://genevamondocs.azurewebsites.net/actions/Quickstart/developFirstGAExtensionCSharp.html
    /// </summary>
    public class PartnerOperationGroup : AcisSMEOperationGroup
    {
        private const string operationGroupNameConst = "Partner";

        /// <summary>
        /// Name of this operation group. Displayed in Jarvis UI prominently
        /// </summary>
        public override string Name => operationGroupNameConst;
    }
}
