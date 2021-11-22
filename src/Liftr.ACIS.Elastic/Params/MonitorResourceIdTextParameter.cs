//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;

namespace Microsoft.Liftr.ACIS.Elastic.Params
{
    public class MonitorResourceIdTextParameter : AcisSMETextParameter
    {
        public override string Name => "Elastic Monitor Resource Id";

        public override string HelpText => "Enter Elastic Monitor Resource Id";
    }
}
