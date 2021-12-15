//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;

namespace Microsoft.Liftr.ACIS
{
    public class ShippingTokenBoolParameter : AcisSMEBooleanParameter
    {
        public override string Name => "Update Shipping Token";

        public override string HelpText => "Update Shipping Token?";
    }
}
