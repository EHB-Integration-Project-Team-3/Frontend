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
    }

    public class ReceiverContextMUUID : AMCDbContext {
        public DbSet<MUUIDReceive> MUUIDS { get; set; }
    }
}

