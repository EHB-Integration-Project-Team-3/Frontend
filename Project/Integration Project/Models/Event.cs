using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Integration_Project.Models
{
    [XmlRoot(ElementName = "event")]
    public class Event
    {
        [XmlElement("header")]
        public Header Header { get; set; }

        [Key]
        [XmlAttribute("uuid")]
        public Guid Uuid { get; set; }

        [XmlAttribute("entityVersion")]
        public int EntityVersion { get; set; }

        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlAttribute("organiserId")]
        public Guid OrganiserId { get; set; }

        [XmlAttribute("description")]
        public string Description { get; set; }

        [XmlAttribute("start")]
        public DateTime Start { get; set; }

        [XmlAttribute("end")]
        public DateTime End { get; set; }

        //[XmlElement("location")]
        public Location Location { get; set; }

        [XmlAttribute("location")]
        public string LocationRabbit { get; set; }
    }
}