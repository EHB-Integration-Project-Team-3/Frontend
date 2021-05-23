using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Integration_Project.Models
{
    [XmlRoot(ElementName = "attendance")]
    public class Attendance
    {
        [XmlElement("header")]
        public Header Header { get; set; }

        [Key]
        [XmlElement("uuid")]
        public Guid Uuid { get; set; }

        [XmlElement("userId")]
        public Guid UserId { get; set; }

        [XmlElement("eventId")]
        public Guid EventId { get; set; }
    }
}