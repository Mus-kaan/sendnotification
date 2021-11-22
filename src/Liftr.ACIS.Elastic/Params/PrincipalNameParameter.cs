﻿//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;

namespace Microsoft.Liftr.ACIS.Elastic.Params
{
    /// <summary>
    /// This class provides the params for Operation method.
    /// </summary>
    public class PrincipalNameParameter : AcisSMETextParameter
    {
        /// <summary>
        /// Enter the text to be shown at UI for Param
        /// </summary>
        public override string Name => "Enter User Principal Name";

        /// <summary>
        /// Help text for param
        /// </summary>
        public override string HelpText => "Please enter Principal Name";
    }
}