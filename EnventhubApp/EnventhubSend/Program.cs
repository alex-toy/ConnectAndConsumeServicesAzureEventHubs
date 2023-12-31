﻿using EventHubHelper;
using System;
using System.Collections.Generic;

namespace EnventhubSend
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SendToOnePartition();
            //SendToMultiplePartition();
        }

        private static void SendToMultiplePartition()
        {
            string connection_string = "Endpoint=sb://alexeieventhub.servicebus.windows.net/;SharedAccessKeyName=send;SharedAccessKey=2z5NErM5vn5wrzQ1A87gpwv1bjKiGjqqM+AEhOsos9Y=;EntityPath=newhub";
            var eventHub = new EventHubSender(connection_string);

            for (int i = 0; i < 20; i++)
            {
                List<Order> _orders = new List<Order>()
                {
                    new Order() {OrderID="O1",Quantity=10,UnitPrice=9.99m,DiscountCategory="Tier 1" },
                    new Order() {OrderID="O2",Quantity=15,UnitPrice=10.99m,DiscountCategory="Tier 2" },
                    new Order() {OrderID="O3",Quantity=20,UnitPrice=11.99m,DiscountCategory="Tier 3" },
                    new Order() {OrderID="O4",Quantity=25,UnitPrice=12.99m,DiscountCategory="Tier 1" },
                    new Order() {OrderID="O5",Quantity=30,UnitPrice=13.99m,DiscountCategory="Tier 2" }
                };

                eventHub.SendBatch(_orders);
                Console.WriteLine("Batch of events sent");
            }
        }

        private static void SendToOnePartition()
        {
            string connection_string = "Endpoint=sb://alexeieventhub.servicebus.windows.net/;SharedAccessKeyName=send;SharedAccessKey=ggxvxTiXZB8b5eyzh3NBo6EyUKb/4zxFx+AEhLKsCuQ=;EntityPath=eventhub";
            var eventHub = new EventHubSender(connection_string);

            List<Order> _orders = new List<Order>()
            {
                new Order() {OrderID="O1",Quantity=10,UnitPrice=9.99m,DiscountCategory="Tier 1" },
                new Order() {OrderID="O2",Quantity=15,UnitPrice=10.99m,DiscountCategory="Tier 2" },
                new Order() {OrderID="O3",Quantity=20,UnitPrice=11.99m,DiscountCategory="Tier 3" },
                new Order() {OrderID="O4",Quantity=25,UnitPrice=12.99m,DiscountCategory="Tier 1" },
                new Order() {OrderID="O5",Quantity=30,UnitPrice=13.99m,DiscountCategory="Tier 2" }
            };

            eventHub.SendBatch(_orders);
            Console.WriteLine("Batch of events sent");
        }
    }
}
