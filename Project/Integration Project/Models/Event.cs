using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [Required(ErrorMessage = "Title is vereist.")]
        [DisplayName("Titel")]
        public string Title { get; set; }

        [XmlElement("organiserId")]
        public Guid OrganiserId { get; set; }

        [XmlElement("description")]
        [DisplayName("Beschrijving")]
        [Required(ErrorMessage = "Beschrijving is vereist.")]
        public string Description { get; set; }

        [XmlElement("start")]
        [Required(ErrorMessage = "Begin datum is vereist.")]
        [DisplayName("Start Datum")]

        public DateTime Start { get; set; }

        [XmlElement("end")]
        [DisplayName("Eind Datum")]
        [Required(ErrorMessage = "Eind datum is vereist.")]

        public DateTime End { get; set; }

        //[XmlElement("location")]
        [XmlIgnore]
        [DisplayName("Locatie")]
        [Required(ErrorMessage = "Locatie is vereist.")]

        public Location Location { get; set; }

        [XmlElement("location")]
        public string LocationRabbit { get; set; }
    }
}