//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;

namespace Microsoft.Liftr.ACIS.Confluent.Params
{
    public class JPathParameter : AcisSMETextParameter
    {
        /// <summary>
        /// Enter the text to be shown at UI for Param
        /// </summary>
        public override string Name => "Enter JPath";

        /// <summary>
        /// Help text for param
        /// </summary>
        public override string HelpText => "Please enter the JSON Path of the property to be updated. For example, If you want to update Plan, enter Path as Properties.InternalMetadata.ConfluentSaasResource.Plan ";
    }
}
