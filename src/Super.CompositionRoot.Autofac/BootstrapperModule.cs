using Autofac;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Super.CompositionRoot.Autofac
{
    public class BootstrapperModule : global::Autofac.Module
    {
        private const string Super = "Super.";

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            var assemblies = GetAssemblies();

            builder
                .RegisterAssemblyTypes(assemblies.ToArray())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterModule(new MediatRModule(assemblies));
        }

        private static IEnumerable<Assembly> GetAssemblies()
        {
            return DependencyContext.Default
                .GetDefaultAssemblyNames()
                .Where(x => x.FullName.StartsWith(Super))
                .Select(x => Assembly.Load(x))
                .ToList();
        }
    }
}
