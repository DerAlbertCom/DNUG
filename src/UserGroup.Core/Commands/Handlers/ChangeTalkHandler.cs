using System.Collections.Generic;
using System.Linq;
using Aperea.Commands;
using Aperea.Data;
using Aperea.Infrastructure.Mappings;
using UserGroup.Entities;

namespace UserGroup.Commands.Handlers
{
    public class ChangeTalkHandler : CommandHandler<ChangeTalk>
    {
        private readonly IRepository<Talk> repository;
        private readonly IRepository<Speaker> speakerRepository;

        public ChangeTalkHandler(IRepository<Talk> repository, IRepository<Speaker> speakerRepository)
        {
            this.repository = repository;
            this.speakerRepository = speakerRepository;
        }

        public override void Execute(ChangeTalk command)
        {
            var talk = repository.Include(c=>c.Speakers).Single(t => t.Id == command.Id);
            var newSpeakers = speakerRepository.Entities.Where(s => command.SpeakerIds.Contains(s.Id)).ToArray();

            talk.Speakers.ChangeCollectionTo(newSpeakers);

            command.MapTo(talk);
            repository.SaveAllChanges();
        }
    }
}