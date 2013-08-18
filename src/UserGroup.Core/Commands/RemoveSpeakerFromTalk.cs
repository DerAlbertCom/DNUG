using Aperea.Commands;
using UserGroup.Entities;

namespace UserGroup.Commands
{
    public class RemoveSpeakerFromTalk : ICommand
    {
        public int SpeakerId { get; private set; }
        public int TalkId { get; private set; }

        public RemoveSpeakerFromTalk(int speakerId, int talkId)
        {
            SpeakerId = speakerId;
            TalkId = talkId;
        }
    }
}