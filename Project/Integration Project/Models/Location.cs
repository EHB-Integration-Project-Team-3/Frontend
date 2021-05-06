using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Integration_Project.Models
{
    [Serializable]
    public class Location
    {
        [Key]
        [XmlAttribute("uuid")]
        public Guid Uuid { get; set; }

        [XmlAttribute("streetName")]
        public string StreetName { get; set; }

        [XmlAttribute("number")]
        public string Number { get; set; }

        [XmlAttribute("city")]
        public string City { get; set; }

        [XmlAttribute("postalCode")]
        public string PostalCode { get; set; }

        public override string ToString()
        {
            return $"{StreetName} {Number} {PostalCode} {City}";
        }
    }
}