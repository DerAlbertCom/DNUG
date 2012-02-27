using System;
using AutoMapper;
using UserGroup.Entities;
using UserGroup.Web.Services;

namespace UserGroup.Web.Mappings
{
    public class LocationUrlResolver : ValueResolver<Location, string>
    {
        readonly IActionUrlBuilder urlBuilder;

        public LocationUrlResolver(IActionUrlBuilder urlBuilder)
        {
            this.urlBuilder = urlBuilder;
        }

        protected override string ResolveCore(Location source)
        {
            if (source == null)
                return null;
            return urlBuilder.GetActionUrl("Details", "ShowLocation", new { slug = source.Slug });
        }
    }
}