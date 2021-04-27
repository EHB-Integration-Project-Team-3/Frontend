using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.RabbitMQ.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Event()
        {
        }

        public Event(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}