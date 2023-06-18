using Azure.Messaging.EventHubs.Consumer;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task GetEvents(int partitionIndex = -1)
        {
            IAsyncEnumerable<PartitionEvent> _events;
            if (partitionIndex == -1)
            {
                _events = _client.ReadEventsAsync();
            }
            else
            {
                string[] partitionIds = await _client.GetPartitionIdsAsync();
                string PartitionID = partitionIds[partitionIndex];
                _events = _client.ReadEventsFromPartitionAsync(PartitionID, EventPosition.Earliest);
            }
                
            await foreach (PartitionEvent _event in _events)
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
