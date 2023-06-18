using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Processor;
using Azure.Storage.Blobs;
using System;
using System.Text;
using System.Threading.Tasks;

namespace EventHubHelper
{
    public class EventhubProcessor
    {
        public EventProcessorClient _processor { get; set; }
        public BlobContainerClient _container_client { get; set; }

        public EventhubProcessor(string storage_account_connection, string container_name, string consumer_group, string eventhub_connection_string)
        {
            _container_client = new BlobContainerClient(storage_account_connection, container_name);
            _processor = new EventProcessorClient(_container_client, consumer_group, eventhub_connection_string);
        }

        public async void Process()
        {
            _processor.ProcessErrorAsync += OurErrorHandler;
            _processor.ProcessEventAsync += OurEventsHandler;

            await _processor.StartProcessingAsync();

            await Task.Delay(TimeSpan.FromSeconds(30));
        }

        public async Task OurEventsHandler(ProcessEventArgs eventArgs)
        {
            Console.WriteLine($"Sequence number {eventArgs.Data.SequenceNumber}");
            Console.WriteLine(Encoding.UTF8.GetString(eventArgs.Data.EventBody));
            await eventArgs.UpdateCheckpointAsync(eventArgs.CancellationToken);
        }

        public Task OurErrorHandler(ProcessErrorEventArgs eventArgs)
        {
            Console.WriteLine(eventArgs.Exception.Message);
            return Task.CompletedTask;
        }
    }
}
