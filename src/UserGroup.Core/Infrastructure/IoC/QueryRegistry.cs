using Aperea;
using Aperea.Infrastructure.IoC;
using StructureMap.Configuration.DSL;
using UserGroup.Queries;

namespace UserGroup.Infrastructure.IoC
{
    [UsedImplicitly]
    public class QueryRegistry : Registry
    {
        public QueryRegistry()
        {
            Scan(s =>
            {
                s.AssembliesForApplication();
                s.ConnectImplementationsToTypesClosing(typeof (IQuery<>));
            });
        }
    }
}