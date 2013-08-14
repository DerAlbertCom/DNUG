using System.Linq;
using Aperea;
using UserGroup.Entities;

namespace UserGroup.Queries
{
    [UsedImplicitly]
    public class FindLocation :  IFindLocation
    {
        private readonly IQuery<Location> locations;

        public FindLocation(IQuery<Location> locations)
        {
            this.locations = locations;
        }

        public Location Execute(int locationid)
        {
            return locations.SingleOrDefault(l => l.Id == locationid);
        }
    }
}