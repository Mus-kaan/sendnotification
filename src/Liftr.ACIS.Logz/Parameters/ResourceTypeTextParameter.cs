//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Wapd.Acis.Contracts.SimplificationClasses;
using System.Collections.Generic;

namespace Microsoft.Liftr.ACIS
{
   public class ResourceTypeTextParameter : AcisSMEStringListParameter
    {
        public override string Name => "Logz Resource Type";

        public override string HelpText => "Select Logz Resource Type";

        public override IEnumerable<string> GetStringValuesForDropdown()
        {
            return new[] { "Microsoft.Logz/monitors", "Microsoft.Logz/monitors/accounts" };
        }
    }
}