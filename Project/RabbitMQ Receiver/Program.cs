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
using System.Threading;
using Integration_Project.Services.MUUIDService;
using Integration_Project.Services.MUUIDService.Interface;

namespace RabbitMQ_Receiver
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Heartbeat
            new Timer((e) => { Rabbit.Send<Heartbeat>(new Heartbeat(), "", Integration_Project.RabbitMQ.Constants.MonitoringHeartbeatQ); }, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));

            //Consumers
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

                    if (XmlController.ValidateXml(message, typeof(Event)))
                    {
                        Event receivedEvent = XmlController.DeserializeXmlString<Event>(message);

                        if (receivedEvent != default)
                            Console.WriteLine($"\nEvent succesfully deserialized");

                        receivedEvent.Location = Location.FromRabbitMQ(receivedEvent.LocationRabbit);

                        try
                        {
                            if (receivedEvent.Header.Method == Method.CREATE)
                            {
                                if (new EventService().Add(receivedEvent))
                                    Console.WriteLine($"\nEvent successfully added to database");
                                else
                                    Console.WriteLine($"\nFailed to add event to database");
                            }
                            else if (receivedEvent.Header.Method == Method.UPDATE)
                            {
                                if (receivedEvent.EntityVersion > new MUUIDService().Get(receivedEvent.Uuid).EntityVersion)
                                    if (new EventService().Update(receivedEvent))
                                        Console.WriteLine($"\nEvent successfully updated in database");
                                    else
                                        Console.WriteLine($"\nFailed to update event in database");
                                else
                                    Console.WriteLine($"\nReceived event is outdated");
                            }
                            else if (receivedEvent.Header.Method == Method.DELETE)
                            {
                                if (new EventService().Delete(receivedEvent.Uuid))
                                    Console.WriteLine($"\nEvent successfully deleted from database");
                                else
                                    Console.WriteLine($"\nFailed to delete event from database");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }
                }
                else if (@event.Exchange == Integration_Project.RabbitMQ.Constants.UserX)
                {
                    Console.WriteLine($"\nReceived User:\n{message}");

                    if (XmlController.ValidateXml(message, typeof(InternalUser)))
                    {
                        InternalUser receivedUser = XmlController.DeserializeXmlString<InternalUser>(message);

                        if (receivedUser != default)
                            Console.WriteLine($"\nUser successfully deserialized");

                        try
                        {
                            if (receivedUser.Header.Method == Method.CREATE)
                            {
                                if (new UserService().Add(receivedUser))
                                {
                                    new MUUIDService().InsertIntoMUUID(new Integration_Project.Models.MUUID.Send.MUUIDSend
                                    {
                                        EntityType = EntityType.User,
                                        Source = Source.FRONTEND,
                                        Source_EntityId = new UserService().Get(receivedUser.Uuid).Uuid.ToString(),
                                    });
                                    Console.WriteLine($"\nUser successfully added to database");
                                }
                                else
                                    Console.WriteLine($"\nFailed to add user to database");
                            }
                            else if (receivedUser.Header.Method == Method.UPDATE)
                            {
                                if (receivedUser.EntityVersion > new MUUIDService().Get(receivedUser.Uuid).EntityVersion)
                                    if (new UserService().Update(receivedUser))
                                        Console.WriteLine($"\nUser successfully updated in database");
                                    else
                                        Console.WriteLine($"\nFailed to update user in database");
                                else
                                    Console.WriteLine($"\nReceived user is outdated");
                            }
                            else if (receivedUser.Header.Method == Method.DELETE)
                            {
                                //if (new UserService().Delete(receivedUser.Uuid))
                                //    Console.WriteLine($"\nUser successfully deleted from database");
                                //else
                                //    Console.WriteLine($"\nFailed to delete user from database");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
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