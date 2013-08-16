using System.Linq;
using Aperea.Commands;
using Aperea.Data;
using Aperea.Infrastructure.Mappings;
using UserGroup.Entities;
using UserGroup.Queries;

namespace UserGroup.Commands.Handlers
{
    public class EditMeetingHandler:CommandHandler<EditMeeting>
    {
        private readonly IRepository<Meeting> repository;
        private readonly IFindLocation location;

        public EditMeetingHandler(IRepository<Meeting> repository, IFindLocation location)
        {
            this.repository = repository;
            this.location = location;
        }

        public override void Execute(EditMeeting command)
        {
            var meeting = repository.Entities.Single(m => m.Id == command.Id);
            meeting.Location = location.Execute(command.LocationId);
            command.MapTo(meeting);
            repository.SaveAllChanges();
        }
    }
}