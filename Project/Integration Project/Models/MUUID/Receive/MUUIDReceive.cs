using Integration_Project.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Models.MUUID.Receive {

    public class MUUIDReceive {
        [Key]
        public Guid MUUID { get; set; }
        public Guid Uuid { get; set; }
        public string Source_EntityId { get; set; }
        public string EntityType { get; set; }
        public int EntityVersion { get; set; }
        public string Source { get; set; }
    }

    public class ReceiverContextMUUID : AMCDbContext {
        public DbSet<MUUIDReceive> MUUIDS { get; set; }
    }
}

