//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;

namespace Microsoft.Liftr.ACIS
{
    public class MonitorResourceIdTextParameter : AcisSMETextParameter
    {
        public override string Name => "Dynatrace Resource Id";

        public override string HelpText => "Enter Dynatrace Resource Id";
    }
}
