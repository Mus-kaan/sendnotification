//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Liftr.ACIS.Datadog.Migration
{
    public class MigrationOperationGroup : AcisSMEOperationGroup
    {
        public const string MigrationOperationGroupName = "Migration";

        public override string Name => MigrationOperationGroupName;
    }
}
