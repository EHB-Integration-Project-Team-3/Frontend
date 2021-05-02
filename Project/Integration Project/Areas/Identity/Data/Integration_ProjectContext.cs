using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration_Project.Areas.Identity.Data;
using Integration_Project.Models.Evenements;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Integration_Project.Data {
    public class Integration_ProjectContext : IdentityDbContext<User> {

        public virtual DbSet<Evenement> Evenements { get; set; }

        public Integration_ProjectContext(DbContextOptions<Integration_ProjectContext> options)
            : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

        }
    }
}
