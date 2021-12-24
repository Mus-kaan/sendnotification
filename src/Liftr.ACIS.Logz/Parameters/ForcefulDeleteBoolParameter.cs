//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;

namespace Microsoft.Liftr.ACIS
{
    public class ForcefulDeleteBoolParameter : AcisSMEBooleanParameter
    {
        public override string Name => "Forceful Delete";

        public override string HelpText => "Forceful Delete?";
    }
}
