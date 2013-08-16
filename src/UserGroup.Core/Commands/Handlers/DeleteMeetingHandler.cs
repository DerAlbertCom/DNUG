using System.Linq;
using Aperea.Commands;
using Aperea.Data;
using UserGroup.Entities;

namespace UserGroup.Commands.Handlers
{
    public class DeleteMeetingHandler : CommandHandler<DeleteMeeting>
    {
        private readonly IRepository<Meeting> repository;

        public DeleteMeetingHandler(IRepository<Meeting> repository)
        {
            this.repository = repository;
        }

        public override void Execute(DeleteMeeting command)
        {
            var meeting = repository.Entities.Single(r => r.Id == command.MeetingId);
            repository.Remove(meeting);
            repository.SaveAllChanges();
        }
    }
}