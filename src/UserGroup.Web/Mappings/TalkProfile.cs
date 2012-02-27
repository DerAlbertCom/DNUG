using AutoMapper;
using UserGroup.Entities;
using UserGroup.Web.Models;

namespace UserGroup.Web.Mappings
{
    public class TalkProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Talk, MeetingDetailsTalkModel>()
                .ForMember(d=>d.TalkUrl,c=>c.ResolveUsing<TalkUrlResolver>());
        }
    }
}