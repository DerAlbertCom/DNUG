using System;
using AutoMapper;
using UserGroup.Entities;
using UserGroup.Web.Models;

namespace UserGroup.Web.Mappings
{
    public class LocationProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Location, ShowLocationModel>();
        }
    }
}