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

            string _byteOrderMarkUtf8 = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());
            if (xmlString.StartsWith(_byteOrderMarkUtf8))
                xmlString = xmlString.Remove(0, _byteOrderMarkUtf8.Length);

            if (xmlString != null)
            {
                var factory = new ConnectionFactory() { Uri = new Uri(Constants.Connection) };
                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();

                var body = Encoding.UTF8.GetBytes(xmlString);

                channel.BasicPublish(
                    exchange: x,
                    routingKey: "",
                    basicProperties: null,
                    body: body);
            }
        }
    }
}