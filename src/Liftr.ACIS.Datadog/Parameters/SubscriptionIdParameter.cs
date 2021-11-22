//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;

namespace Microsoft.Liftr.ACIS.Datadog.Parameters
{
    public class SubscriptionIdParameter : AcisSMETextParameter
    {
        /// <summary>
        /// Enter the text to be shown at UI for Param
        /// </summary>
        public override string Name => "Enter Subscription Id";

        /// <summary>
        /// Help text for param
        /// </summary>
        public override string HelpText => "Please enter Subscription Id";
    }
}
