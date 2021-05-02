using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Models.Evenements {
    public class Evenement {
        [Key]
        public Guid Uuid { get; set; }
        public int EntityVersion { get; set; }
        public string Title { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        //public Location Location { get; set; }
    }
}
