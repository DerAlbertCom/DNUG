using Microsoft.Practices.ServiceLocation;

namespace UserGroup.Queries
{
    public class QueryFactory : IQueryFactory
    {
        private readonly IServiceLocator locator;

        public QueryFactory(IServiceLocator locator)
        {
            this.locator = locator;
        }

        public T Create<T>() where T : IQuery
        {
            return locator.GetInstance<T>();
        }
    }
}