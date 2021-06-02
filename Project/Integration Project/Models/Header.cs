using Integration_Project.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Integration_Project.Models
{
    [Serializable]
    [NotMapped]
    public class Header
    {
        [XmlElement("method")]
        public Method Method { get; set; }

        [XmlElement("source")]
        public Source Source { get; set; }

        public Header()
        {
            Source = Source.FRONTEND;
        }
    }
}