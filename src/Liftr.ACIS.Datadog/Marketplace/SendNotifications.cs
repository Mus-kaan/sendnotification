//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Liftr.Datadog.Service;
using Microsoft.Liftr.ACIS.Relay;
using Microsoft.Liftr.Contracts;
using Microsoft.Liftr.Contracts.ARM;
using Microsoft.Liftr.Datadog.Service;
using Microsoft.Liftr.Datadog.Service.Contracts;
using Microsoft.Liftr.Datadog.Service.Models;
using Microsoft.Liftr.RPaaS;
using Microsoft.Liftr.Utilities;
using Microsoft.WindowsAzure.Storage;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Microsoft.Liftr.Datadog.ACIS.Datadog
{
    public class SendNotifications
    {
        private const int resultsLimit = 100;
        private readonly IMetaRPStorageClient _metaRPClient;
        private readonly ITenantHelper _tenantHelper;
        private readonly ILogger _logger;
        private readonly IResourceEntityDataSource _ResourceEntityDataSource;
       
        public SendNotifications
    (
            IMetaRPStorageClient metaRPClient,
            ITenantHelper tenantHelper,
            IResourceEntityDataSource EntityDataSource,
            ILogger logger)
        {
            _metaRPClient = metaRPClient ?? throw new ArgumentNullException(nameof(metaRPClient));
            _tenantHelper = tenantHelper ?? throw new ArgumentNullException(nameof(tenantHelper));
            _ResourceEntityDataSource = EntityDataSource ?? throw new ArgumentNullException(nameof(EntityDataSource));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<List<string>> GetAllDatadogMonitorsAsync(IACISOperation operation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            List<string> responseList = new List<string>();
            try
            {
                await operation.LogInfoAsync("Started fetching the datadog monitors from the collection");
                List<ResourceEntity> datadogResourceList = await _ResourceEntityDataSource.GetAllDatadogMonitorsAsync();
                await operation.LogInfoAsync("Fetched the datadog monitors from the collection");
                datadogResourceList.ForEach(datadogResource =>
                {
                    responseList.Add(datadogResource.ResourceId);
                    _logger.Information("The resource id is {resourceId}", datadogResource.ResourceId);
                });
                await operation.LogInfoAsync($"The count of the monitors : {responseList.Count}");
                string resourceIdList = string.Join(",", responseList);
                await operation.SuccessfulFinishAsync(resourceIdList);
            }
            catch (Exception ex)
            {
                _logger.Error("Exception occured while executing the operation : {exception} with stackTrace {stackTrace}", ex.Message, ex.StackTrace);
                await operation.LogErrorAsync("Error occured while executing the operation");
                await operation.FailAsync("Failed to execute the operation");
            }

            return responseList;
        }

       
    }
}
