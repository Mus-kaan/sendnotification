//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;

namespace Microsoft.Liftr.ACIS
{
   public class ResourceIdTextParameter : AcisSMETextParameter
    {
        public override string Name => "Datadog Monitored Resource Id";

        public override string HelpText => "Datadog Moniotred Resource Id";
    }
}