using System.Linq;
using Aperea.Commands;
using Aperea.Data;
using UserGroup.Entities;

namespace UserGroup.Commands.Handlers
{
    public class AddSpeakerToTalkHandler:CommandHandler<AddSpeakerToTalk>
    {
        private readonly IRepository<Talk> repository;
        private readonly IRepository<Speaker> speakerRepository;

        public AddSpeakerToTalkHandler(IRepository<Talk> repository, IRepository<Speaker> speakerRepository)
        {
            this.repository = repository;
            this.speakerRepository = speakerRepository;
        }

        public override void Execute(AddSpeakerToTalk command)
        {
            var talk = repository.Include(t=>t.Speakers).Single(t => t.Id == command.TalkId);
            var speaker = speakerRepository.Entities.Single(s => s.Id == command.SpeakerId);
            if (!talk.Speakers.Contains(speaker))
            {
                talk.Speakers.Add(speaker);
                repository.SaveAllChanges();
            }
        }
    }
}