using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using UserGroup.Data;
using UserGroup.Entities;

namespace UserGroup.Web.Mappings.Resolver
{
    public class LocationSelectListResolver : ValueResolver<IHasLocation, IEnumerable<SelectListItem>>
    {
        readonly IRepository<Location> repository;

        public LocationSelectListResolver(IRepository<Location> repository)
        {
            this.repository = repository;
        }

        protected override IEnumerable<SelectListItem> ResolveCore(IHasLocation source)
        {
            var query = from l in repository.Entities
                        orderby l.Name
                        select new {Text = l.Name, Value = l.Id};
            var empty = new {Text = "<auswählen>", Value = 0};
            return new SelectList(new[] {empty}.Concat(query.ToList()), "Value", "Text", GetSelectedValue(source));
        }

        static int GetSelectedValue(IHasLocation source)
        {
            var locationId = 0;
            if (source !=null && source.Location != null)
                locationId = source.Location.Id;
            return locationId;
        }
    }
}