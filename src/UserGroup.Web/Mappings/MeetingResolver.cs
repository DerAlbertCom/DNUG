using System;
using System.Linq;
using AutoMapper;
using UserGroup.Data;
using UserGroup.Entities;

namespace UserGroup.Web.Mappings
{
    public class MeetingResolver : ValueResolver<int, Meeting>
    {
        readonly IRepository<Meeting> repository;

        public MeetingResolver(IRepository<Meeting> repository)
        {
            this.repository = repository;
        }

        protected override Meeting ResolveCore(int source)
        {
            return repository.Entities.SingleOrDefault(l => l.Id == source);
        }
    }
}