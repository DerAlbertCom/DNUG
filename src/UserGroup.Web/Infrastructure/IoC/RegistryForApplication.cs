using System;
using Aperea.Data;
using Aperea.Identity;
using Aperea.Infrastructure.IoC;
using StructureMap;
using StructureMap.Configuration.DSL;
using UserGroup.Data;
using UserGroup.Services;
using UserGroup.Web.Security;

namespace UserGroup.Web.Infrastructure.IoC
{
    public class RegistryForApplication : Registry
    {
        public RegistryForApplication()
        {
            For<IRelyingPartyConfiguration>().Use<RelyingPartyConfiguration>();
            Scan(
                s =>
                {
                    s.AssembliesForApplication();
                    s.ConnectImplementationsToTypesClosing(typeof (ISlugGenerator<>))
                     .OnAddedPluginTypes(c => c.LifecycleIs(InstanceScope.Singleton));
                    s.With(new WebApiControllerConvention());
                });

            For<ISlugGeneratorFactory>().Singleton();
            For<IDatabaseContext>().HybridHttpOrThreadLocalScoped();
            For<UserGroupDbContext>().Use<UserGroupDbContext>();
            For(typeof (IRepository<>)).HybridHttpOrThreadLocalScoped().Use(
                typeof (Repository<>));
        }
    }
}