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
    public class HeaderAttendance
    {
        [XmlElement("method")]
        public Method Method { get; set; }
    }
}