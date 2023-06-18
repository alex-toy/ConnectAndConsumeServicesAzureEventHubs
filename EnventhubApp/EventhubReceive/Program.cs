using EventHubHelper;
using System;
using System.Threading.Tasks;

namespace EventhubReceive
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string connection_string = "Endpoint=sb://alexeieventhub.servicebus.windows.net/;SharedAccessKeyName=receive;SharedAccessKey=bb6jUqwShxalJYGaSbvlOVhVYzaWGd/To+AEhJ4+uFQ=;EntityPath=eventhub";
            string consumer_group = "$Default";

            var eventHubReceiver = new EventHubReceiver(connection_string, consumer_group);

            eventHubReceiver.GetEvents().Wait();

            Console.ReadKey();
        }
    }
}
