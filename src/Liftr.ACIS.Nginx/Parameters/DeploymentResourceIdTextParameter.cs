//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts;

namespace Microsoft.Liftr.ACIS.Nginx.Parameters
{
    public class DeploymentResourceIdTextParameter : AcisSMETextParameter
    {
        public override string Name => "Nginx Deployment Resource Id";

        public override string HelpText => "Nginx Deployment Resource Id";
    }
}
