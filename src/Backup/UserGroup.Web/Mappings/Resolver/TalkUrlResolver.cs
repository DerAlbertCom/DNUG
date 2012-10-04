using System;
using AutoMapper;
using UserGroup.Entities;
using UserGroup.Web.Services;

namespace UserGroup.Web.Mappings.Resolver
{
    public class TalkUrlResolver : ValueResolver<Talk, string>
    {
        readonly IActionUrlBuilder urlBuilder;

        public TalkUrlResolver(IActionUrlBuilder urlBuilder)
        {
            this.urlBuilder = urlBuilder;
        }

        protected override string ResolveCore(Talk source)
        {
            return urlBuilder.GetActionUrl("Details", "ShowTalk", new { slug = source.Slug });
        }
    }
}