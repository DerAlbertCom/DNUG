using System;
using System.Web.Http;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace UserGroup.Web.Infrastructure.IoC
{
    public class WebApiControllerConvention : IRegistrationConvention
    {
        public void Process(Type type, Registry registry)
        {
            if (!type.IsAbstract && typeof (ApiController).IsAssignableFrom(type))
            {
                registry.AddType(type, type);
            }
        }
    }
}