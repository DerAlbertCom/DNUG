using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using UserGroup.Data;
using UserGroup.Entities;

namespace UserGroup.Web.Mappings.Resolver
{
    public class LocationSelectListResolver : ValueResolver<int, IEnumerable<SelectListItem>>
    {
        readonly IRepository<Location> repository;

        public LocationSelectListResolver(IRepository<Location> repository)
        {
            this.repository = repository;
        }

        protected override IEnumerable<SelectListItem> ResolveCore(int source)
        {
            var query = from l in repository.Entities
                        orderby l.Name
                        select new {Text = l.Name, Value = l.Id};
            var items = from i in query.ToList()
                        select
                            new SelectListItem() { Text = i.Text, Value = i.Value.ToString(CultureInfo.InvariantCulture), Selected = i.Value.ToString(CultureInfo.InvariantCulture) == source.ToString(CultureInfo.InvariantCulture) };
            var empty = new SelectListItem {Text = "<auswählen>", Value = 0.ToString(CultureInfo.InvariantCulture)};

            return new[] {empty}.Concat(items.ToList());
        }
    }
}