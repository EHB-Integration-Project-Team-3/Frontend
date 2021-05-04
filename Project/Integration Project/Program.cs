using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using Integration_Project.Models;
using Integration_Project.RabbitMQ;
using System.Threading;
using System.Threading.Tasks;
using RabbitMQ.Client.Events;
using System.Text;
using System.Diagnostics;
using RabbitMQ.Client;

namespace Integration_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new Timer((e) => { Rabbit.Send<Heartbeat>(new Heartbeat(), RabbitMQ.Constants.WarningX, RabbitMQ.Constants.MonitoringHeartbeatQ); }, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
            //Rabbit.ReceiveEvents<Event>();

            //Process.Start(@"D:\GitHub\Frontend\Project\RabbitMQ Receiver\RabbitMQ Receiver.csproj");

            var factory = new ConnectionFactory() { HostName = RabbitMQ.Constants.Connection, DispatchConsumersAsync = true };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: RabbitMQ.Constants.FrontendEventQ,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.Received += Consumer_Received;

            channel.BasicConsume(queue: RabbitMQ.Constants.FrontendEventQ,
                                         autoAck: true,
                                         consumer: consumer);

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

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