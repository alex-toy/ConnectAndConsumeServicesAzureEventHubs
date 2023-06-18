using EventHubHelper;
using System;
using System.Threading.Tasks;

namespace EventhubReceive
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //ReceiveFromOnePartition();
            //ReceiveFromMultiplePartition();
            ReceiveFromFirstPartition();

            Console.ReadKey();
        }

        private static void ReceiveFromFirstPartition()
        {
            string connection_string = "Endpoint=sb://alexeieventhub.servicebus.windows.net/;SharedAccessKeyName=listen;SharedAccessKey=oK23Qv3/tSg8UuXuDgdE58p4UUwqhchV0+AEhPriffo=;EntityPath=newhub";
            string consumer_group = "$Default";

            var eventHubReceiver = new EventHubReceiver(connection_string, consumer_group);

            eventHubReceiver.GetEvents(0).Wait();
        }

        private static void ReceiveFromMultiplePartition()
        {
            string connection_string = "Endpoint=sb://alexeieventhub.servicebus.windows.net/;SharedAccessKeyName=listen;SharedAccessKey=oK23Qv3/tSg8UuXuDgdE58p4UUwqhchV0+AEhPriffo=;EntityPath=newhub";
            string consumer_group = "$Default";

            var eventHubReceiver = new EventHubReceiver(connection_string, consumer_group);

            eventHubReceiver.GetEvents().Wait();
        }

        private static void ReceiveFromOnePartition()
        {
            string connection_string = "Endpoint=sb://alexeieventhub.servicebus.windows.net/;SharedAccessKeyName=receive;SharedAccessKey=bb6jUqwShxalJYGaSbvlOVhVYzaWGd/To+AEhJ4+uFQ=;EntityPath=eventhub";
            string consumer_group = "$Default";

            var eventHubReceiver = new EventHubReceiver(connection_string, consumer_group);

            eventHubReceiver.GetEvents().Wait();
        }
    }
}
