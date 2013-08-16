using AutoMapper;
using UserGroup.Commands;
using UserGroup.Entities;

namespace UserGroup.Infrastructure.Mappings
{
    public class MeetingMappings : Profile
    {
        protected override void Configure()
        {
            CreateMap<AddMeeting, Meeting>()
                .IgnoreMember(d => d.Id)
                .IgnoreMember(d => d.Slug)
                .IgnoreMember(d => d.Talks)
                .IgnoreMember(d => d.Location)
                .ForMember(d => d.StartTime, c => c.ResolveUsing(s => s.StartTime.ToUniversalTime()))
                .ForMember(d => d.DisplayFrom, c => c.ResolveUsing(s => s.DisplayFrom.ToUniversalTime()));

            CreateMap<EditMeeting, Meeting>()
                .IgnoreMember(d => d.Talks)
                .IgnoreMember(d => d.Location)
                .ForMember(d => d.StartTime, c => c.ResolveUsing(s => s.StartTime.ToUniversalTime()))
                .ForMember(d => d.DisplayFrom, c => c.ResolveUsing(s => s.DisplayFrom.ToUniversalTime()));

            base.Configure();
        }
    }
}