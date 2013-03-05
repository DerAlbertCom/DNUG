using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using Aperea.Data;
using AutoMapper;
using UserGroup.Data;
using UserGroup.Entities;

namespace UserGroup.Web.Mappings.Resolver
{
    public class SpeakerSelectListResolver : ValueResolver<int, IEnumerable<SelectListItem>>
    {
        readonly IRepository<Speaker> repository;

        public SpeakerSelectListResolver(IRepository<Speaker> repository)
        {
            this.repository = repository;
        }

        protected override IEnumerable<SelectListItem> ResolveCore(int source)
        {
            var query = from l in repository.Entities
                        orderby l.LastName, l.GivenName
                        select new {Text = l.LastName + ", " + l.GivenName, Value = l.Id};

            var items = from i in query.ToList()
                        select
                            new SelectListItem()
                                {
                                    Text = i.Text,
                                    Value = i.Value.ToString(CultureInfo.InvariantCulture),
                                    Selected =
                                        i.Value.ToString(CultureInfo.InvariantCulture) ==
                                        source.ToString(CultureInfo.InvariantCulture)
                                };
            var empty = new SelectListItem {Text = "<auswählen>", Value = 0.ToString(CultureInfo.InvariantCulture)};

            return new[] {empty}.Concat(items.ToList());
        }
    }
}