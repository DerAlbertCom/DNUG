using AutoMapper;
using UserGroup.Commands;
using UserGroup.Entities;

namespace UserGroup.Infrastructure.Mappings
{
    public class TalkMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<AddTalkToMeeting, Talk>()
                .IgnoreMember(d => d.Id)
                .IgnoreMember(d => d.Slug)
                .IgnoreMember(d => d.Meeting)
                .IgnoreMember(d => d.Speakers);
            CreateMap<ChangeTalk, Talk>()
                .IgnoreMember(d => d.Meeting)
                .IgnoreMember(d => d.Speakers);


            base.Configure();
        }
    }
}