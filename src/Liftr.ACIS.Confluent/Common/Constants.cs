//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

namespace Microsoft.Liftr.ACIS.Confluent.Common
{
    public static class Constants
    {
        public const string ACISStorConn = "ACISStorConn";
        public const string FetchSaasResourceIdOperationName = "FetchSaasResourceId";
        public const string FetchResourceInfoOperationName = "FetchResourceInfo";
        public const string FetchResourceInfoForProviderOperationName = "FetchResourceInfoForProvider";
        public const string ActivationFailedWebhookOperationName = "ActivationFailedWebhook";
        public const string DeleteResourceFailedWebhookOperationName = "DeleteResourceFailedWebhook";
        public const string UpdateResourceConfigOperationName = "UpdateResourceConfig";
        public const string FetchListOfResourcesOperationName = "FetchListOfResources";
        public const string ConfluentJITScope = "LiftrConfluent";
        public const string FetchActiveCustomerEmailOperationName = "FetchActiveUserEmail";
    }
}
