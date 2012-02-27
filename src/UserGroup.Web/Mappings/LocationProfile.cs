using System;
using AutoMapper;
using UserGroup.Entities;
using UserGroup.Web.Areas.Backoffice.Models;
using UserGroup.Web.Models;

namespace UserGroup.Web.Mappings
{
    public class LocationProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Location, ShowLocationModel>();
            CreateMap<Location, EditLocationModel>();
            CreateMap<EditLocationModel, Location>()
                .ForMember(d=>d.Slug,c=>c.Ignore());
        }
    }
}