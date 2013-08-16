using Aperea.Commands;

namespace UserGroup.Commands
{
    public class RemoveTalkFromMeeting : ICommand
    {
        public int TalkId { get; private set; }
        public int MeetingId { get; private set; }

        public RemoveTalkFromMeeting(int talkId, int meetingId)
        {
            TalkId = talkId;
            MeetingId = meetingId;
        }
    }
}