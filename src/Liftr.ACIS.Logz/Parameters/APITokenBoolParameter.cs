//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;

namespace Microsoft.Liftr.ACIS
{
    public class APITokenBoolParameter : AcisSMEBooleanParameter
    {
        public override string Name => "Update API Token";

        public override string HelpText => "Update API Token?";
    }
}
