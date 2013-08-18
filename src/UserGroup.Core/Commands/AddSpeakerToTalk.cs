using Aperea.Commands;

namespace UserGroup.Commands
{
    public class AddSpeakerToTalk : ICommand
    {
        public int SpeakerId { get; private set; }
        public int TalkId { get; private set; }

        public AddSpeakerToTalk(int speakerId, int talkId)
        {
            SpeakerId = speakerId;
            TalkId = talkId;
        }
    }
}