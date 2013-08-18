using System.Linq;
using Aperea.Commands;
using Aperea.Data;
using UserGroup.Entities;

namespace UserGroup.Commands.Handlers
{
    public class RemoveSpeakerFromTalkHandler : CommandHandler<RemoveSpeakerFromTalk>
    {
        private readonly IRepository<Talk> repository;

        public RemoveSpeakerFromTalkHandler(IRepository<Talk> repository)
        {
            this.repository = repository;
        }

        public override void Execute(RemoveSpeakerFromTalk command)
        {
            var talk = repository.Include("Speakers").Single(t => t.Id == command.TalkId);
            var speaker = talk.Speakers.Single(s => s.Id == command.SpeakerId);
            talk.Speakers.Remove(speaker);
            repository.SaveAllChanges();
        }
    }
}