using Aperea.Identity;
using DotnetKoeln.STS.Services;
using DotnetKoeln.STS.TokenService;
using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMap.Pipeline;

namespace DotnetKoeln.STS.Infrastructure
{
    public class StsRegistry : Registry
    {
        public StsRegistry()
        {
            For<ISleepService>().LifecycleIs(Lifecycles.GetLifecycle(InstanceScope.Singleton));
            For<IIdentityProviderConfiguration>().Use<IdentityProviderConfiguration>();
        }
    }
}