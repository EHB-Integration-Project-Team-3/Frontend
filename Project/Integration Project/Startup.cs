using Autofac;
using Autofac.Core.Activators.Reflection;
using Autofac.Extensions.DependencyInjection;
using Integration_Project;
using Integration_Project.Areas.Identity.Data;
using Integration_Project.Models;
using Integration_Project.Services;
using Integration_Project.Services.EventService;
using Integration_Project.Services.EventService.Interface;
using Integration_Project.Services.MUUIDService;
using Integration_Project.Services.MUUIDService.Interface;
using Integration_Project.Services.UserService;
using Integration_Project.Services.UserService.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Integration_Project {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {

            var start = new start();

            //services.AddScoped<IEventService, EventService>();
            services.AddScoped<IMUUIDService, MUUIDService>();
            //services.AddScoped<IUserService, UserService>();
     

            // eigen DBcontext service voor connectie naar eigen database
            services.AddDbContext<Integration_ProjectContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            var _connectionStringMUUID = Configuration.GetConnectionString("MUUIDConnection");
            services.AddDbContext<AMCDbContext>(
                options => options.UseMySql(
                    _connectionStringMUUID
                )
            );


            // service om eigen usermodel aan ingebakken identityRole te linken

            services.AddIdentity<User, IdentityRole>(options => {
                options.User.RequireUniqueEmail = false;
            }).AddDefaultTokenProviders()
                .AddEntityFrameworkStores<Integration_ProjectContext>();


            services.AddAuthentication(IISDefaults.AuthenticationScheme);
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddMvc()
                .AddSessionStateTempDataProvider()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();
            services.AddSession();


        }

        public static ConstructorFinder InternalConstructorFinder = new ConstructorFinder(BindingFlags.Default | BindingFlags.NonPublic
| BindingFlags.Public | BindingFlags.Instance);

        private void LoadServices(ContainerBuilder builder) {

            var assembly = Assembly.GetExecutingAssembly();
            builder
                .RegisterAssemblyTypes(assembly)
                .AssignableTo<IBaseService>()
                .AsImplementedInterfaces()
                .InstancePerRequest();


        }


        public class ConstructorFinder : IConstructorFinder {
            private readonly BindingFlags _bindingFlags;
            public ConstructorFinder(BindingFlags flags) {
                _bindingFlags = flags;
            }
            public ConstructorInfo[] FindConstructors(Type targetType) {
                return targetType.GetConstructors(_bindingFlags);
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            } else {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseSession();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

        }
    }
}
