using RabbitMQ.Client;
using System;
using Integration_Project.RabbitMQ;
using System.Threading.Tasks;
using RabbitMQ.Client.Events;
using System.Text;
using Integration_Project.Models;
using Integration_Project.Services.EventService;

namespace RabbitMQ_Receiver
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { Uri = new Uri(Integration_Project.RabbitMQ.Constants.Connection), DispatchConsumersAsync = true };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.Received += Consumer_Received;

            channel.BasicConsume(queue: Integration_Project.RabbitMQ.Constants.FrontendEventQ,
                                         autoAck: true,
                                         consumer: consumer);

            Console.WriteLine("Waiting for message...");
            Console.ReadLine();
        }

        private static async Task Consumer_Received(object sender, BasicDeliverEventArgs @event)
        {
            try
            {
                var eventService = new EventService();

                var message = Encoding.UTF8.GetString(@event.Body.ToArray());
                Console.WriteLine($"\nReceived Message:\n{message}");
                Event receivedEvent = XmlController.DeserializeXmlString<Event>(message);

                receivedEvent.Location = Location.FromRabbitMQ(receivedEvent.LocationRabbit);
                eventService.Add(receivedEvent);

                Console.WriteLine($"\nSuccesfully deserialized");

                await Task.Delay(250);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}