//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using Microsoft.Liftr.ACIS.Logging;
using Microsoft.Liftr.Contracts;
using Microsoft.Liftr.DataSource.Mongo;
using Microsoft.Liftr.DataSource.Mongo.MonitoringSvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Liftr.Management
{
    public class EventHubManagement
    {
        private readonly IAcisLogger _logger;
        private readonly EventHubEntityDataSource _evhDataSource;

        public EventHubManagement(MonitoringSvcMongoOptions options, IAcisLogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            var factory = new MongoCollectionsFactory(options, _logger.Logger);
            var timeSource = new SystemTimeSource();

            var collection = factory
                    .GetOrCreateEventHubEntityCollectionAsync(options.EventHubSourceEntityCollectionName)
                    .GetAwaiter()
                    .GetResult();

            _evhDataSource = new EventHubEntityDataSource(collection, factory.MongoWaitQueueProtector, timeSource);
        }

        public async Task<IEnumerable<EventHubRecord>> ListAsync()
        {
            _logger.LogInfo("Retrieving event hub meta data from RP DB ...");
            var list = await _evhDataSource.ListAsync();
            return list.Select(i => new EventHubRecord(i));
        }
    }
}
