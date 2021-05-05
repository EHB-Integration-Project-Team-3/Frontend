using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Integration_Project.Models
{
    [XmlRoot(ElementName = "attendance ")]
    public class Attendance
    {
        [Key]
        [XmlAttribute("uuid")]
        public Guid Uuid { get; set; }

        [XmlAttribute("userId")]
        public Guid UserId { get; set; }

        [XmlAttribute("eventId")]
        public Guid EventId { get; set; }
    }
}