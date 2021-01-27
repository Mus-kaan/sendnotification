//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;

namespace Microsoft.Liftr.ACIS.Params
{
    public class EventhubNamespaceNameParameter : AcisSMETextParameter
    {
        public override string Name => "Eventhub Namespace Name";

        public override string HelpText => "The name of the Eventhub Namespace that will be updated";
    }
}
