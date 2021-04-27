using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Integration_Project.RabbitMQ.Models
{
    [XmlRoot(ElementName = "User")]
    public class User
    {
        public User()
        {
        }

        public User(string name, string lastName, int age, string email)
        {
            Name = name;
            LastName = lastName;
            Email = email;
        }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("lastName")]
        public string LastName { get; set; }

        [XmlAttribute("age")]
        public int Age { get; set; }

        [XmlAttribute("email")]
        public string Email { get; set; }
    }
}