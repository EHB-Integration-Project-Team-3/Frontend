using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Integration_Project.Models
{
    [Serializable]
    public class Header
    {
        [XmlAttribute("Method")]
        public Method Method { get; set; }

        [XmlAttribute("Source")]
        public Source Source { get; set; }
    }
}