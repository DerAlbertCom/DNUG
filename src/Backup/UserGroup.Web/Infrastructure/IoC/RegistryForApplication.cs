using Aperea.Identity;
using Aperea.Infrastructure.IoC;
using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMap.Pipeline;
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
                        s.AssembliesFromApplicationBaseDirectory(StructureMapAssemblyFilter.Filter);
                        s.ConnectImplementationsToTypesClosing(typeof (ISlugGenerator<>)).OnAddedPluginTypes(c => c.LifecycleIs(InstanceScope.Singleton));
                    });

            For<ISlugGeneratorFactory>().LifecycleIs(Lifecycles.GetLifecycle(InstanceScope.Singleton));
            For(typeof (IRepository<>)).LifecycleIs(Lifecycles.GetLifecycle(InstanceScope.Hybrid)).Use(
                typeof (Repository<>));
            For(typeof(IDatabaseContext)).LifecycleIs(Lifecycles.GetLifecycle(InstanceScope.Hybrid));
        }
    }
}