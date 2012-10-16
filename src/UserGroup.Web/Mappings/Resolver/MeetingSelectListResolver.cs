using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using UserGroup.Data;
using UserGroup.Entities;

namespace UserGroup.Web.Mappings.Resolver
{
    public class MeetingSelectListResolver : ValueResolver<int, IEnumerable<SelectListItem>>
    {
        readonly IRepository<Meeting> repository;

        public MeetingSelectListResolver(IRepository<Meeting> repository)
        {
            this.repository = repository;
        }

        protected override IEnumerable<SelectListItem> ResolveCore(int source)
        {
            var query = from l in repository.Entities
                        orderby l.StartTime descending 
                        select new { Text = l.Title, Value = l.Id };

            var items = from i in query.ToList()
                        select
                            new SelectListItem() { Text = i.Text, Value = i.Value.ToString(CultureInfo.InvariantCulture), Selected = i.Value.ToString(CultureInfo.InvariantCulture) == source.ToString(CultureInfo.InvariantCulture) };
            var empty = new SelectListItem { Text = "<auswählen>", Value = 0.ToString(CultureInfo.InvariantCulture) };

            return new[] { empty }.Concat(items.ToList());
        }
    }
}