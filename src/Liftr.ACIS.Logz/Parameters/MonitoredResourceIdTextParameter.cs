//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;

namespace Microsoft.Liftr.ACIS
{
   public class MonitoredResourceIdTextParameter : AcisSMETextParameter
    {
        public override string Name => "Logz Monitored Resource Id";

        public override string HelpText => "Logz Monitored Resource Id";
    }
}