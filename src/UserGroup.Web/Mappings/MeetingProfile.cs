using AutoMapper;
using UserGroup.Entities;
using UserGroup.Web.Areas.Backoffice.Models;
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

            CreateMap<Meeting, ShowMeetingModel>()
                .ForMember(d => d.StartTime, c => c.ResolveUsing(s => s.StartTime.ToLocalTime().TimeOfDay))
                .ForMember(d => d.StartDate, c => c.ResolveUsing(s => s.StartTime.ToLocalTime().Date))
                .ForMember(d => d.LocationUrl, c => c.ResolveUsing<LocationUrlResolver>().FromMember(s=>s.Location));

            CreateMap<Meeting, EditMeetingModel>();

            CreateMap<EditMeetingModel, Meeting>()
                .ForMember(d => d.Slug, c => c.Ignore())
                .ForMember(d => d.Id, c => c.Ignore())
                .ForMember(d => d.Location, c => c.Ignore())
                .ForMember(d => d.StartTime, c => c.ResolveUsing(s => s.StartTime.ToUniversalTime()))
                .ForMember(d => d.DisplayFrom, c => c.ResolveUsing(s => s.DisplayFrom.ToUniversalTime()))
                .ForMember(d => d.Talks, c => c.Ignore());
        }
    }
}