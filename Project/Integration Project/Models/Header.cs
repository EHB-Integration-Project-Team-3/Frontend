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
        [XmlAttribute("Method")]
        public Method Method { get; set; }

        [XmlAttribute("Source")]
        public Source Source { get; set; }
    }
}