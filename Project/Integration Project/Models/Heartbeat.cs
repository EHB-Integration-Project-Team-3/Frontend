using Integration_Project.Models.Enums;
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
        [XmlElement("header")]
        public HeaderHeartbeat HeaderHeartbeat { get; set; }

        [XmlElement("timeStamp")]
        public DateTime TimeStamp { get; set; }

        public Heartbeat()
        {
            TimeStamp = DateTime.Now;
            HeaderHeartbeat = new HeaderHeartbeat() { Status = Status.ONLINE };
        }
    }
}