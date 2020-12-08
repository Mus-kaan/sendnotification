//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;

namespace Microsoft.Liftr.ACIS.Confluent.Params
{
    public class XPathParameter : AcisSMETextParameter
    {
        /// <summary>
        /// Enter the text to be shown at UI for Param
        /// </summary>
        public override string Name => "Enter xpath";

        /// <summary>
        /// Help text for param
        /// </summary>
        public override string HelpText => "Please enter xpath of the property to be updated";
    }
}
