using RabbitMQ.Client;
using System.Text;

namespace Integration_Project.RabbitMQ
{
    public class Rabbit
    {
        public static void Send<T>(T data)
        {
            string xmlString = XmlController.SerializeToXmlString(data);

            if (xmlString != null)
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };
                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();

                channel.QueueDeclare(
                    queue: "helloitsme",
                    exclusive: false,
                    durable: false,
                    autoDelete: false,
                    arguments: null);

                var body = Encoding.UTF8.GetBytes(xmlString);

                channel.BasicPublish(
                    exchange: "",
                    routingKey: "helloitsme",
                    basicProperties: null,
                    body: body);
            }
        }

        //public static void Receive<T>()
        //{
        //deserialize
        //}
    }
}