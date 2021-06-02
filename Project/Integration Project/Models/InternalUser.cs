using Integration_Project.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Integration_Project.Models
{
    [XmlRoot(ElementName = "user")]
    [Serializable]
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

        public InternalUser()
        {
        }

        //public InternalUser(Header header, Guid uuid, int entityVersion, string lastName, string firstName, string emailAddress, Role role)
        //{
        //    Header = header;
        //    Uuid = uuid;
        //    EntityVersion = entityVersion;
        //    LastName = lastName;
        //    FirstName = firstName;
        //    EmailAddress = emailAddress;
        //    Role = role;
        //}
    }
}