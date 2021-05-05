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
        public static void Send<T>(T data, string x, string q = "")
        {
            string xmlString = XmlController.SerializeToXmlString(data);

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
    }
}