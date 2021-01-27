//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;

namespace Microsoft.Liftr.ACIS.Params
{
    public class EvhIngestEnabledParameter : AcisSMEBooleanParameter
    {
        public override string Name => "Ingest enable";

        public override string HelpText => "If this Eventhub is enabled for ingesting data from OBO.";
    }
}
