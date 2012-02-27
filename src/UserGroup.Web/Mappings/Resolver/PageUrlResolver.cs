using System;
using AutoMapper;
using UserGroup.Entities;
using UserGroup.Web.Services;

namespace UserGroup.Web.Mappings.Resolver
{
    public class PageUrlResolver : ValueResolver<Page, string>
    {
        readonly IActionUrlBuilder urlBuilder;

        public PageUrlResolver(IActionUrlBuilder urlBuilder)
        {
            this.urlBuilder = urlBuilder;
        }

        protected override string ResolveCore(Page source)
        {
            return urlBuilder.GetActionUrl("Details", "ShowPage", new { slug = source.Slug });
        }
    }
}