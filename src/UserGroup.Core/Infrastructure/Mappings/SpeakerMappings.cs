using AutoMapper;
using UserGroup.Commands;
using UserGroup.Entities;

namespace UserGroup.Infrastructure.Mappings
{
    public class SpeakerMappings : Profile
    {
        protected override void Configure()
        {
            CreateMap<CreateSpeaker, Speaker>()
                .IgnoreMember(d => d.Id)
                .IgnoreMember(d => d.Slug);

            CreateMap<ChangeSpeaker, Speaker>();
            base.Configure();
        }
    }
}