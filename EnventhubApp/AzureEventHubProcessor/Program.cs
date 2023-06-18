using EventHubHelper;
using System;

namespace AzureEventHubProcessor
{
    internal class Program
    {
        private static string eventhub_connection_string = "Endpoint=sb://alexeieventhub.servicebus.windows.net/;SharedAccessKeyName=receive;SharedAccessKey=bb6jUqwShxalJYGaSbvlOVhVYzaWGd/To+AEhJ4+uFQ=;EntityPath=eventhub";
        private static string consumer_group = "$Default";
        private static string storage_account_connection = "DefaultEndpointsProtocol=https;AccountName=hubstoresa;AccountKey=CIbXwgWEOHc8ELs27ASzqnMaorXu5php67ieF6ngs13+MrHItO+ycLRKqHiRUmCZjjkw37hAAICh+AStIz2liA==;EndpointSuffix=core.windows.net";
        private static string container_name = "eventhub";

        static void Main(string[] args)
        {
            var eventhubProcessor = new EventhubProcessor(storage_account_connection, container_name, consumer_group, eventhub_connection_string);
            eventhubProcessor.Process();
        }
    }
}
