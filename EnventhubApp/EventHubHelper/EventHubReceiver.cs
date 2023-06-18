using Azure.Messaging.EventHubs.Consumer;
using System;
using System.Text;
using System.Threading.Tasks;

namespace EventHubHelper
{
    public class EventHubReceiver
    {
        public EventHubConsumerClient _client { get; set; }

        public EventHubReceiver(string connection_string, string consumer_group)
        {
            _client = new EventHubConsumerClient(consumer_group, connection_string);
        }

        public async Task GetEvents()
        {
            await foreach (PartitionEvent _event in _client.ReadEventsAsync())
            {
                Console.WriteLine($"Partition ID {_event.Partition.PartitionId}");
                Console.WriteLine($"Data Offset {_event.Data.Offset}");
                Console.WriteLine($"Sequence Number {_event.Data.SequenceNumber}");
                Console.WriteLine($"Partition Key {_event.Data.PartitionKey}");
                Console.WriteLine(Encoding.UTF8.GetString(_event.Data.EventBody));
            }
        }
    }
}
