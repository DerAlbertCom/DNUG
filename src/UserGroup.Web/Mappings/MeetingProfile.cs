using AutoMapper;
using UserGroup.Entities;
using UserGroup.Infrastructure.Mappings.Resolver;
using UserGroup.Web.Areas.BackOffice.Models;
using UserGroup.Web.Mappings.Resolver;
using UserGroup.Web.Models;

namespace UserGroup.Web.Mappings
{
    public class MeetingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Meeting, MeetingLineModel>()
                .ForMember(d => d.StartTime, c => c.ResolveUsing(s => s.StartTime.ToLocalTime().TimeOfDay))
                .ForMember(d => d.StartDate, c => c.ResolveUsing(s => s.StartTime.ToLocalTime().Date))
                .ForMember(d => d.MeetingDetailUrl, c => c.ResolveUsing<MeetingUrlResolver>());

            CreateMap<Meeting, DisplayMeetingLineModel>()
                .ForMember(d => d.StartTime, c => c.ResolveUsing(s => s.StartTime.ToLocalTime().TimeOfDay))
                .ForMember(d => d.StartDate, c => c.ResolveUsing(s => s.StartTime.ToLocalTime().Date));

            CreateMap<Meeting, ShowMeetingModel>()
                .ForMember(d => d.StartTime, c => c.ResolveUsing(s => s.StartTime.ToLocalTime().TimeOfDay))
                .ForMember(d => d.StartDate, c => c.ResolveUsing(s => s.StartTime.ToLocalTime().Date))
                .ForMember(d => d.LocationUrl, c => c.ResolveUsing<LocationUrlResolver>().FromMember(s => s.Location));

            CreateMap<Meeting, EditMeetingModel>()
                .ForMember(d => d.LocationSelectList,
                           c => c.ResolveUsing<LocationSelectListResolver>())
                .ForMember(d => d.StartTime, c => c.ResolveUsing(s => s.StartTime.ToLocalTime()))
                .ForMember(d => d.DisplayFrom, c => c.ResolveUsing(s => s.DisplayFrom.ToLocalTime()));

            CreateMap<EditMeetingModel, Meeting>()
                .ForMember(d => d.Slug, c => c.Ignore())
                .ForMember(d => d.Id, c => c.Ignore())
                .ForMember(d => d.Location, c => c.ResolveUsing<LocationResolver>().FromMember(s => s.LocationId))
                .ForMember(d => d.StartTime, c => c.ResolveUsing(s => s.StartTime.ToUniversalTime()))
                .ForMember(d => d.DisplayFrom, c => c.ResolveUsing(s => s.DisplayFrom.ToUniversalTime()))
                .ForMember(d => d.Talks, c => c.Ignore());
        }
    }
}