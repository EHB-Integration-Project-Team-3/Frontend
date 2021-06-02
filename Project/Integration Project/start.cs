using Autofac;
using Integration_Project.Services.EventService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project {
    public class start : Module {
        protected override void Load(ContainerBuilder builder) {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            builder
                .RegisterAssemblyTypes(assemblies)
                .Where(t => t.GetInterfaces().Any(i => i.IsAssignableFrom(typeof(IBaseService))))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope(); // Add similar for the other two lifetimes
            base.Load(builder);
        }
    }
}
