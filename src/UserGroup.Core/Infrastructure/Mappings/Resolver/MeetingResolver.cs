using System.Linq;
using Aperea;
using Aperea.Data;
using AutoMapper;
using UserGroup.Entities;

namespace UserGroup.Infrastructure.Mappings.Resolver
{
    [UsedImplicitly]
    public sealed class MeetingResolver : ValueResolver<int, Meeting>
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