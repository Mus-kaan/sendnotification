//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;

namespace Microsoft.Liftr.ACIS
{
    public class DescriptionIdTextParameter : AcisSMETextParameter
    {
        public override string Name => "Description Id";

        public override string HelpText => "Enter the issue";
    }
}
