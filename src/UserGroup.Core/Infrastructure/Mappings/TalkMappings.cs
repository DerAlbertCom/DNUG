using AutoMapper;
using UserGroup.Commands;
using UserGroup.Entities;

namespace UserGroup.Infrastructure.Mappings
{
    public class TalkMappings : Profile
    {
        protected override void Configure()
        {
            CreateMap<ChangeTalk, Talk>()
                .IgnoreMember(d => d.Id)
                .IgnoreMember(d => d.Meeting)
                .IgnoreMember(d => d.Speakers);

            CreateMap<AddTalkToMeeting, Talk>()
                .IgnoreMember(d => d.Id)
                .IgnoreMember(d => d.Slug)
                .IgnoreMember(d => d.Meeting)
                .IgnoreMember(d => d.Speakers);


            base.Configure();
        }
    }
}