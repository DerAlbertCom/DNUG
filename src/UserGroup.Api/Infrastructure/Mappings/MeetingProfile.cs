using AutoMapper;
using UserGroup.Api.Models;
using UserGroup.Entities;

namespace UserGroup.Api.Infrastructure.Mappings
{
    public class MeetingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Meeting, DisplayMeetingLineModel>()
                .ForMember(d => d.StartTime, c => c.ResolveUsing<UtcDateTimeToLocalTimeSpan>().FromMember(s=>s.StartTime))
                .ForMember(d => d.StartDate, c => c.ResolveUsing<UtcDateTimeToLocalDate>().FromMember(s=>s.StartTime));
            base.Configure();
        }
    }
}