//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;

namespace Microsoft.Liftr.ACIS.Datadog.Parameters
{
    public class DiagnosticSettingsNameParameter : AcisSMETextParameter
    {
        /// <summary>
        /// Enter the text to be shown at UI for Param
        /// </summary>
        public override string Name => "Enter Diagnostic Settings Id";

        /// <summary>
        /// Help text for param
        /// </summary>
        public override string HelpText => "Please enter diagnostic settings Id";
    }
}
