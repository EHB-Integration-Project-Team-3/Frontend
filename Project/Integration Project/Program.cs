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

            //var receiver = Process.Start(@"..\RabbitMQ Receiver\bin\Release\netcoreapp3.1\RabbitMQ Receiver");

            CreateHostBuilder(args).Build().Run();
            //receiver.Kill();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}