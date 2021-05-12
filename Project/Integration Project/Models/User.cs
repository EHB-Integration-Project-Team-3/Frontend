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
        [XmlElement("header")]
        public Header Header { get; set; }

        [Key]
        [XmlElement("uuid")]
        public Guid Uuid { get; set; }

        [XmlElement("entityVersion")]
        public int EntityVersion { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("emailAddress")]
        public string EmailAddress { get; set; }

        [XmlElement("role")]
        public Role Role { get; set; }
    }
}