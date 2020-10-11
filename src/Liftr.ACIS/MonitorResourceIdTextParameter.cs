//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;

namespace Microsoft.Liftr.ACIS
{
    public class MonitorResourceIdTextParameter : AcisSMETextParameter
    {
        public override string Name => "Datadog Monitor Resource Id";

        public override string HelpText => "Datadog Monitor Resource Id";
    }
}
