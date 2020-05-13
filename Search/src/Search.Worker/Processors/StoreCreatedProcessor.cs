using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Catalog.Messages;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Search.Worker.Processors
{
    public class StoreCreatedProcessor : QueueWorker<StoreCreated>
    {
        public StoreCreatedProcessor(IConfiguration configuration, ILogger<StoreCreatedProcessor> logger)
            : base(configuration, logger, Constants.StoreCreated)
        {
        }

        protected override async Task ProcessMessage(StoreCreated store, string messageId, Message.SystemPropertiesCollection systemProperties, IDictionary<string, object> userProperties, CancellationToken cancellationToken)
        {
           
        }


    }
}
