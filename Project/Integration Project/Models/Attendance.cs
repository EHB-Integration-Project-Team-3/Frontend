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
        public HeaderAttendance Header { get; set; }

        [Key]
        [XmlElement("uuid")]
        public Guid Uuid { get; set; }

        [XmlElement("creatorId")]
        public Guid CreatorId { get; set; }

        [XmlElement("attendeeId")]
        public Guid AttendeeId { get; set; }

        [XmlElement("eventId")]
        public Guid EventId { get; set; }

        public Attendance()
        {
        }

        public Attendance(HeaderAttendance header, Guid uuid, Guid creatorId, Guid attendeeId, Guid eventId)
        {
            Header = header;
            Uuid = uuid;
            CreatorId = creatorId;
            AttendeeId = attendeeId;
            EventId = eventId;
        }
    }
}