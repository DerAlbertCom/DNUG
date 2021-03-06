﻿using AutoMapper;
using UserGroup.Entities;
using UserGroup.Web.Areas.BackOffice.Models;
using UserGroup.Web.Mappings.Resolver;
using UserGroup.Web.Models;

namespace UserGroup.Web.Mappings
{
    public class SpeakerProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Speaker, EditSpeakerModel>();
            CreateMap<Speaker, DisplaySpeakerLineModel>();
            CreateMap<Speaker, ShowSpeakerModel>();
            CreateMap<EditSpeakerModel, Speaker>()
                .ForMember(c => c.Slug, c => c.Ignore());

            CreateMap<Speaker, SpeakerLineModel>()
                 .ForMember(d => d.SpeakerUrl, c => c.ResolveUsing<SpeakerUrlResolver>()); 
        }
    }
}