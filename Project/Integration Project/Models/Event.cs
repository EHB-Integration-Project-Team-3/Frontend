using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Integration_Project.Models {
    [XmlRoot(ElementName = "event")]
    public class Event {

        [XmlElement("header")]
        public Header Header { get; set; }

        [Key]
        public int Id { get; set; }

        [XmlElement("uuid")]
        public Guid Uuid { get; set; }

        [XmlElement("entityVersion")]
        public int EntityVersion { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("organiserId")]
        public Guid OrganiserId { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("start")]
        public DateTime Start { get; set; }

        [XmlElement("end")]
        public DateTime End { get; set; }

        //[XmlElement("location")]
        [XmlIgnore]
        public Location Location { get; set; }

        [XmlElement("location")]
        public string LocationRabbit { get; set; }
    }
}