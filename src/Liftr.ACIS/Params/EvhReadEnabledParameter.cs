//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;

namespace Microsoft.Liftr.ACIS.Params
{
    public class EvhReadEnabledParameter : AcisSMEBooleanParameter
    {
        public override string Name => "Read enable";

        public override string HelpText => "If this Eventhub is enabled for LogForwarder to read data from it.";
    }
}
