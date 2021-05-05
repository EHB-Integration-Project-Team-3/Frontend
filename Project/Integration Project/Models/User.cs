using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Integration_Project.Models
{
    [XmlRoot(ElementName = "user")]
    public class InternalUser
    {
        [Key]
        [XmlAttribute("uuid")]
        public Guid Uuid { get; set; }

        [XmlAttribute("entityVersion")]
        public int EntityVersion { get; set; }

        [XmlAttribute("lastName")]
        public string LastName { get; set; }

        [XmlAttribute("firstName")]
        public string FirstName { get; set; }

        [XmlAttribute("emailAddress")]
        public string EmailAddress { get; set; }

        [XmlAttribute("role")]
        public Role Role { get; set; }
    }
}