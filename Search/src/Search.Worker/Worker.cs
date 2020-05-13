using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Search.Worker
{
    public abstract class QueueWorker<TMessage> : BackgroundService
    {
        protected ILogger<QueueWorker<TMessage>> _logger { get; }
        protected IConfiguration _configuration { get; }
        protected string _queue;

        public QueueWorker(IConfiguration configuration,
            ILogger<QueueWorker<TMessage>> logger,
            string queue)
        {
            _configuration = configuration;
            _logger = logger;
            _queue = queue;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var connectionString = _configuration.GetConnectionString("QueueStorageConnection");

            var queueClient = new QueueClient(connectionString, this._queue);

            _logger.LogInformation("Starting message pump");
            queueClient.RegisterMessageHandler(HandleMessage, HandleReceivedException);
            _logger.LogInformation("Message pump started");

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
            }

            _logger.LogInformation("Closing message pump");
            await queueClient.CloseAsync();
            _logger.LogInformation("Message pump closed : {Time}", DateTimeOffset.UtcNow);
        }

        private Task HandleReceivedException(ExceptionReceivedEventArgs exceptionEvent)
        {
            _logger.LogError(exceptionEvent.Exception, "Unable to process message");
            return Task.CompletedTask;
        }

        protected abstract Task ProcessMessage(TMessage message, string messageId, Message.SystemPropertiesCollection systemProperties, IDictionary<string, object> userProperties, CancellationToken cancellationToken);

        private async Task HandleMessage(Message message, CancellationToken cancellationToken)
        {
            var rawMessageBody = Encoding.UTF8.GetString(message.Body);
            _logger.LogInformation("Received message {MessageId} with body {MessageBody}", message.MessageId, rawMessageBody);

            var order = JsonConvert.DeserializeObject<TMessage>(rawMessageBody);
            if (order != null)
            {
                await ProcessMessage(order, message.MessageId, message.SystemProperties, message.UserProperties, cancellationToken);
            }
            else
            {
                _logger.LogError("Unable to deserialize to message contract {ContractName} for message {MessageBody}", typeof(TMessage), rawMessageBody);
            }

            _logger.LogInformation("Message {MessageId} processed", message.MessageId);
        }
    }
}
