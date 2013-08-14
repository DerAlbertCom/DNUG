using System.Linq;
using Aperea;
using Aperea.Data;
using AutoMapper;
using UserGroup.Entities;

namespace UserGroup.Infrastructure.Mappings.Resolver
{
    [UsedImplicitly]
    public class LocationResolver : ValueResolver<int, Location>
    {
        private readonly IRepository<Location> repository;

        public LocationResolver(IRepository<Location> repository)
        {
            this.repository = repository;
        }

        protected override Location ResolveCore(int source)
        {
            return repository.Entities.SingleOrDefault(l => l.Id == source);
        }
    }
}