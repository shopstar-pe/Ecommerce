using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Catalog.Application.Abstractions;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Catalog.Infrastructure.Messaging
{
    public class QueueBusService : IBusService
    {
        private readonly string _connectionString;
        private readonly ILogger<QueueBusService> _logger;
        
        public QueueBusService(string connectionString, ILogger<QueueBusService> logger)
        {
            this._connectionString = connectionString;
            this._logger = logger;
            
        }

        public async Task Publish<T>(string queue, List<T> data) where T : class, new()
        {
            var cloudQueue = new QueueClient(this._connectionString, queue);

            await PublishToQueue(cloudQueue, data);
        }

        private async Task PublishToQueue<T>(QueueClient cloudQueue, List<T> data)
        {
            var messages = new List<Message>();

            foreach (var item in data)
            {
                // Create a new message to send to the topic.
                var json = JsonConvert.SerializeObject(item);
                var message = new Message(Encoding.UTF8.GetBytes(json));

                messages.Add(message);

                this._logger.LogInformation($"Data => {json}");
            }

            this._logger.LogInformation($"Sending message to Topic {cloudQueue.QueueName}");

            // Send the message to the topic.
            await cloudQueue.SendAsync(messages);

            this._logger.LogInformation($"Done message to Topic {cloudQueue.QueueName}");
        }
    }
}
