//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Liftr.ACIS.Dynatrace
{
    /// <summary>
    /// Each Extension contains one more operation groups.
    /// This enables extension owners to group (categorize) operations into meaningful groups for ease of management.
    /// </summary>
    public class DynatraceOperationGroup : AcisSMEOperationGroup
    {
        private const string RPaaSOperationGroupName = "RPaaS";

        /// <summary>
        /// Name of this operation group. Displayed in Jarvis UI prominently
        /// </summary>
        public override string Name => RPaaSOperationGroupName;
    }
}
