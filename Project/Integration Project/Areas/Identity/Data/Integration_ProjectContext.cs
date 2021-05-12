using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration_Project.Areas.Identity.Data;
using Integration_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Integration_Project.Areas.Identity.Data {
    public class Integration_ProjectContext : DbContext {

        private const string _connectionString = @"Data Source=10.3.17.65\SQLEXPRESS,1433;Initial Catalog=IntegrationFrontendDB;Persist Security Info=True;User ID=Administrator;Password=poi987POI";
        public Integration_ProjectContext() {

        }

        public Integration_ProjectContext(DbContextOptions<Integration_ProjectContext> options)
            : base(options) {

        }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<InternalUser> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlServer(
                    _connectionString
                    );
            }
        }

        protected override void OnModelCreating(ModelBuilder builder) {

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
