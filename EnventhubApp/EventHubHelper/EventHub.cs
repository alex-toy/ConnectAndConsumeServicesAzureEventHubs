using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventHubHelper
{
    public class EventHub
    {
        public EventHubProducerClient _client { get; set; }
        public EventDataBatch _batch { get; set; }

        public EventHub(string connection_string)
        {
            _client = new EventHubProducerClient(connection_string);
            _batch = _client.CreateBatchAsync().GetAwaiter().GetResult();
        }

        public void SendBatch<T>(List<T> items)
        {
            var items_string = Stringify(items);
            foreach (string item in items_string)
            {
                var eventData = new EventData(Encoding.UTF8.GetBytes(item));
                _batch.TryAdd(eventData);
            }

            _client.SendAsync(_batch).GetAwaiter().GetResult();
        }

        private List<string> Stringify<T>(List<T> items)
        {
            List<string> orders = items.Select(o => o.ToString()).ToList();
            return orders;
        }
    }
}
