using Aperea;
using Aperea.Commands;
using Aperea.Data;
using Aperea.Infrastructure.Mappings;
using UserGroup.Entities;
using UserGroup.Queries;
using UserGroup.Services;

namespace UserGroup.Commands.Handlers
{
    [UsedImplicitly]
    public sealed class CreateMeetingHandler : CommandHandler<CreateMeeting>
    {
        private readonly IRepository<Meeting> meetings;
        private readonly IFindLocation location;
        private readonly ISlugGenerator<Meeting> slug;

        public CreateMeetingHandler(IRepository<Meeting> meetings, IFindLocation location, ISlugGenerator<Meeting> slug)
        {
            this.meetings = meetings;
            this.location = location;
            this.slug = slug;
        }

        public override void Execute(CreateMeeting command)
        {
            var meeting = command.MapTo<Meeting>();
            slug.Generate(meeting);
            meeting.Location = location.Execute(command.LocationId);
            meetings.Add(meeting);
            meetings.SaveAllChanges();
        }
    }
}