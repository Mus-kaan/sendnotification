//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;

namespace Microsoft.Liftr.ACIS
{
    public class NotifyPartnerBoolParameter : AcisSMEBooleanParameter
    {
        public override string Name => "Notify Logz.io Partner";

        public override string HelpText => "Notify Logz.io Partner?";
    }
}
