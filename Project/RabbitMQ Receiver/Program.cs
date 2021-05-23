using RabbitMQ.Client;
using System;
using Integration_Project.RabbitMQ;
using System.Threading.Tasks;
using RabbitMQ.Client.Events;
using System.Text;
using Integration_Project.Models;
using Integration_Project.Services.EventService;
using Integration_Project.Models.Enums;
using Integration_Project.Services.UserService;

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
            channel.BasicConsume(queue: Integration_Project.RabbitMQ.Constants.FrontendUserQ,
                                         autoAck: true,
                                         consumer: consumer);

            Console.WriteLine("\nWaiting for message...");
            Console.ReadLine();
        }

        private static async Task Consumer_Received(object sender, BasicDeliverEventArgs @event)
        {
            try
            {
                var message = Encoding.UTF8.GetString(@event.Body.ToArray());

                if (@event.Exchange == Integration_Project.RabbitMQ.Constants.EventX)
                {
                    Console.WriteLine($"\nReceived Event:\n{message}");

                    Event receivedEvent = XmlController.DeserializeXmlString<Event>(message);

                    if (receivedEvent != default)
                        Console.WriteLine($"\nEvent succesfully deserialized");

                    receivedEvent.Location = Location.FromRabbitMQ(receivedEvent.LocationRabbit);

                    if (receivedEvent.Header.Method == Method.CREATE)
                    {
                        if (new EventService().Add(receivedEvent))
                            Console.WriteLine($"\nEvent successfully added to Frontend database");
                    }
                    else if (receivedEvent.Header.Method == Method.UPDATE)
                    {
                        if (new EventService().Update(receivedEvent))
                            Console.WriteLine($"\nEvent successfully updated in Frontend database");
                    }
                    else if (receivedEvent.Header.Method == Method.DELETE)
                    {
                        if (new EventService().Delete(receivedEvent.Uuid))
                            Console.WriteLine($"\nEvent successfully deleted from Frontend database");
                    }
                }
                else if (@event.Exchange == Integration_Project.RabbitMQ.Constants.UserX)
                {
                    Console.WriteLine($"\nReceived User:\n{message}");

                    InternalUser receivedUser = XmlController.DeserializeXmlString<InternalUser>(message);

                    if (receivedUser != default)
                        Console.WriteLine($"\nUser succesfully deserialized");

                    if (receivedUser.Header.Method == Method.CREATE)
                    {
                        if (new UserService().Add(receivedUser))
                            Console.WriteLine($"\nUser successfully added to Frontend database");
                    }
                    else if (receivedUser.Header.Method == Method.UPDATE)
                    {
                        if (new UserService().Update(receivedUser))
                            Console.WriteLine($"\nUser successfully updated in Frontend database");
                    }
                    else if (receivedUser.Header.Method == Method.DELETE)
                    {
                        //if (new UserService().Delete(receivedUser.Uuid))
                        //    Console.WriteLine($"\nUser successfully deleted from Frontend database");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine("\nWaiting for message...");
                await Task.Delay(1000);
            }
        }
    }
}