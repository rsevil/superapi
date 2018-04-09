using Autofac;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration configuration;

        public BootstrapperModule(IConfiguration configuration)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            var assemblies = GetAssemblies();

            builder
                .RegisterAssemblyTypes(assemblies.ToArray())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterModule(new MediatRModule(assemblies));

            builder
                .Register(e => new System.Data.SqlClient.SqlConnection(configuration.GetConnectionString("SuperDatabase")))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
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
