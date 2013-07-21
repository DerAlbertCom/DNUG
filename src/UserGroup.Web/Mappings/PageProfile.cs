using System;
using AutoMapper;
using UserGroup.Entities;
using UserGroup.Web.Areas.BackOffice.Models;
using UserGroup.Web.Mappings.Resolver;
using UserGroup.Web.Models;

namespace UserGroup.Web.Mappings
{
    public class PageProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Page, ShowPageModel>()
                .ForMember(d=>d.PageUrl,c=>c.ResolveUsing<PageUrlResolver>());

            CreateMap<Page, EditPageModel>();
            CreateMap<EditPageModel, Page>();
        }
    }
}