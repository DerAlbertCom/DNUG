using System;
using System.Linq;
using AutoMapper;
using UserGroup.Data;
using UserGroup.Entities;

namespace UserGroup.Web.Mappings
{
    public class LocationResolver : ValueResolver<int, Location>
    {
        readonly IRepository<Location> repository;

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