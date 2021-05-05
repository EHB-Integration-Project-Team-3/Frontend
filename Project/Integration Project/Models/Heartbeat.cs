using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Integration_Project.Models
{
    [XmlRoot(ElementName = "Heartbeat ")]
    public class Heartbeat
    {
        [XmlAttribute("timeStamp")]
        public DateTime TimeStamp { get; set; }

        [XmlAttribute("source")]
        public Source Source { get; set; }
    }
}