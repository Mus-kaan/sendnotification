//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;

namespace Microsoft.Liftr.ACIS
{
    public class RPaaSDeleteBoolParameter : AcisSMEBooleanParameter
    {
        public override string Name => "Delete from RPaaS";

        public override string HelpText => "Delete from RPaaS?";
    }
}
