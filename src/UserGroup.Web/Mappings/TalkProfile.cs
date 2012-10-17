using AutoMapper;
using UserGroup.Entities;
using UserGroup.Web.Areas.Backoffice.Models;
using UserGroup.Web.Mappings.Resolver;
using UserGroup.Web.Models;

namespace UserGroup.Web.Mappings
{
    public class TalkProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Talk, MeetingDetailsTalkModel>()
                .ForMember(d => d.TalkUrl, c => c.ResolveUsing<TalkUrlResolver>());

            CreateMap<Talk, DisplayTalkLineModel>();

            CreateMap<Talk, DisplayTalkModel>()
                .ForMember(d => d.SpeakerSelectList, c => c.ResolveUsing<SpeakerSelectListResolver>().FromMember(s => 0));

            CreateMap<Talk, EditTalkModel>()
                .ForMember(d => d.MeetingSelectList,
                           c => c.ResolveUsing<MeetingSelectListResolver>());

            CreateMap<EditTalkModel, Talk>()
                .ForMember(c => c.Slug, c => c.Ignore())
                .ForMember(c => c.Meeting, c => c.ResolveUsing<MeetingResolver>().FromMember(s => s.MeetingId))
                .ForMember(c => c.Speakers, c => c.Ignore());
        }
    }
}