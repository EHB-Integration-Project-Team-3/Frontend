using Integration_Project.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Integration_Project.RabbitMQ
{
    public class Rabbit
    {
        public static void Send<T>(T data, string x, string q)
        {
            string xmlString = XmlController.SerializeToXmlString(data);

            //save to database and continue if succesfuly saved

            if (xmlString != null)
            {
                var factory = new ConnectionFactory() { HostName = Constants.Connection };
                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();

                channel.QueueDeclare(
                    queue: q,
                    exclusive: false,
                    durable: false,
                    autoDelete: false,
                    arguments: null);

                var body = Encoding.UTF8.GetBytes(xmlString);

                channel.BasicPublish(
                    exchange: x,
                    routingKey: q,
                    basicProperties: null,
                    body: body);
            }
        }

        public static void ReceiveEvents<Event>()
        {
            var factory = new ConnectionFactory() { HostName = Constants.Connection, DispatchConsumersAsync = true };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: Constants.FrontendEventQ,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.Received += Consumer_Received;

            channel.BasicConsume(queue: Constants.FrontendEventQ,
                                         autoAck: true,
                                         consumer: consumer);

            Debug.WriteLine(" Press [enter] to exit.");
        }

        private static async Task Consumer_Received(object sender, BasicDeliverEventArgs @event)
        {
            var message = Encoding.UTF8.GetString(@event.Body.ToArray());
            Event receivedEvent = XmlController.DeserializeXmlString<Event>(message);

            Debug.WriteLine($"Begin processing {message}");

            await Task.Delay(250);

            Debug.WriteLine($"End processing {receivedEvent.Title}");
        }
    }
}