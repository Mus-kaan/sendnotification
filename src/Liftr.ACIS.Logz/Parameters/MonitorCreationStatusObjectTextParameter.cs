//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;

namespace Microsoft.Liftr.ACIS
{
    public class MonitorCreationStatusObjectTextParameter : AcisSMETextParameter
    {
        public override string Name => "Monitor Creation Status Object";

        public override string HelpText => "Enter Monitor Creation Status Object";
    }
}
