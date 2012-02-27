using System;
using AutoMapper;
using UserGroup.Entities;
using UserGroup.Web.Services;

namespace UserGroup.Web.Mappings
{
    public class MeetingUrlResolver : ValueResolver<Meeting, string>
    {
        readonly IActionUrlBuilder urlBuilder;

        public MeetingUrlResolver(IActionUrlBuilder urlBuilder)
        {
            this.urlBuilder = urlBuilder;
        }

        protected override string ResolveCore(Meeting source)
        {
            return urlBuilder.GetActionUrl("Details", "ShowMeeting", new {slug = source.Slug});
        }
    }
}