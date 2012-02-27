using System;
using AutoMapper;
using UserGroup.Entities;
using UserGroup.Web.Services;

namespace UserGroup.Web.Mappings
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

    public class SpeakerUrlResolver : ValueResolver<Speaker, string>
    {
        readonly IActionUrlBuilder urlBuilder;

        public SpeakerUrlResolver(IActionUrlBuilder urlBuilder)
        {
            this.urlBuilder = urlBuilder;
        }

        protected override string ResolveCore(Speaker source)
        {
            return urlBuilder.GetActionUrl("Details", "ShowSpeaker", new { slug = source.Slug });
        }
    }
}