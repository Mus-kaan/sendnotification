//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;

namespace Microsoft.Liftr.ACIS
{
    public class NotificationContentIdTextParameter : AcisSMETextParameter
    {
        public override string Name => "Notification Content Id";

        public override string HelpText => "Enter the content of the notification";
    }
}
