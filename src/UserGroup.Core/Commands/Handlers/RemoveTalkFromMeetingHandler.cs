using System.ComponentModel;
using System.Linq;
using Aperea.Commands;
using Aperea.Data;
using UserGroup.Entities;

namespace UserGroup.Commands.Handlers
{
    public class RemoveTalkFromMeetingHandler : CommandHandler<RemoveTalkFromMeeting>
    {
        private readonly IRepository<Meeting> repository;

        public RemoveTalkFromMeetingHandler(IRepository<Meeting> repository)
        {
            this.repository = repository;
        }

        public override void Execute(RemoveTalkFromMeeting command)
        {
            var meeting = repository.Include(m=>m.Talks).Single(m => m.Id == command.MeetingId);
            var talk = meeting.Talks.Single(t => t.Id==command.TalkId);
            meeting.Talks.Remove(talk);
            repository.SaveAllChanges();
        }
    }
}