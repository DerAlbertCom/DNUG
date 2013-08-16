using Aperea.Commands;

namespace UserGroup.Commands
{
    public class DeleteMeeting : ICommand
    {
        public int MeetingId { get; private set; }

        public DeleteMeeting(int meetingId)
        {
            MeetingId = meetingId;
        }
    }
}