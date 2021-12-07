//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;

namespace Microsoft.Liftr.ACIS
{
    public class RPaaSObjectTextParameter : AcisSMETextParameter
    {
        public override string Name => "RPaaS Object";

        public override string HelpText => "Enter RPaaS Object";
    }
}
