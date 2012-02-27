using AutoMapper;
using UserGroup.Entities;
using UserGroup.Web.Areas.Backoffice.Models;
using UserGroup.Web.Models;

namespace UserGroup.Web.Mappings
{
    public class SpeakerProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Speaker, EditSpeakerModel>();
            CreateMap<Speaker, ShowSpeakerModel>();
            CreateMap<EditSpeakerModel, Speaker>()
                .ForMember(c => c.Slug, c => c.Ignore());

            CreateMap<Speaker, SpeakerLineModel>()
                 .ForMember(d => d.SpeakerUrl, c => c.ResolveUsing<SpeakerUrlResolver>()); 
        }
    }
}