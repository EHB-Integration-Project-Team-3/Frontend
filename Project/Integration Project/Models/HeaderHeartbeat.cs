using Integration_Project.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Integration_Project.Models
{
    [NotMapped]
    [Serializable]
    public class HeaderHeartbeat
    {
        [XmlElement("status")]
        public Status Status { get; set; }

        [XmlElement("source")]
        public Source Source { get; set; }

        public HeaderHeartbeat()
        {
            Source = Source.FRONTEND;
        }
    }
}