//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;

namespace Microsoft.Liftr.ACIS.Nginx.Parameters
{
    /// <summary>
    /// This class provides the params for Operation method.
    /// </summary>
    public class ResourceGroupNameTextParameter : AcisSMETextParameter
    {
        /// <summary>
        /// Enter the text to be shown at UI for Param
        /// </summary>
        public override string Name => "Enter Resource Group";

        /// <summary>
        /// Help text for param
        /// </summary>
        public override string HelpText => "Please enter resource group name";
    }
}
