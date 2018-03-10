using Autofac;
using MediatR;
using Super.Core.Data.EF.MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Super.CompositionRoot.Autofac
{
    public class MediatRModule : global::Autofac.Module
    {
        private readonly IEnumerable<Assembly> assemblies;

        public MediatRModule(IEnumerable<Assembly> assemblies)
        {
            this.assemblies = assemblies;
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            // mediator
            builder
                .RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            // request handlers resolving
            builder
                .Register<SingleInstanceFactory>(ctx =>
                {
                    var c = ctx.Resolve<IComponentContext>();
                    return t => { return c.TryResolve(t, out object o) ? o : null; };
                })
                .InstancePerLifetimeScope();

            // notification handlers resolving
            builder
                .Register<MultiInstanceFactory>(ctx =>
                {
                    var c = ctx.Resolve<IComponentContext>();
                    return t => (IEnumerable<object>)c.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
                })
                .InstancePerLifetimeScope();

            // request handlers
            foreach (var assembly in assemblies)
            {
                RegisterHandlers(builder, assembly);
            }

            builder
                .RegisterGeneric(typeof(TransactionalBehavior<,>))
                .As(typeof(IPipelineBehavior<,>))
                .InstancePerLifetimeScope();
        }

        private static void RegisterHandlers(ContainerBuilder builder, Assembly assembly)
        {
            builder
                .RegisterAssemblyTypes(assembly)
                .As(t => t.GetInterfaces().Where(i => i.IsClosedTypeOf(typeof(IRequestHandler<>))))
                .InstancePerLifetimeScope();

            builder
                .RegisterAssemblyTypes(assembly)
                .As(t => t.GetInterfaces().Where(i => i.IsClosedTypeOf(typeof(IRequestHandler<,>))))
                .InstancePerLifetimeScope();

            builder
                .RegisterAssemblyTypes(assembly)
                .As(t => t.GetInterfaces().Where(i => i.IsClosedTypeOf(typeof(INotificationHandler<>))))
                .InstancePerLifetimeScope();
        }
    }
}
