using System.Linq;
using Aperea.Commands;
using Aperea.Data;
using Aperea.Infrastructure.Mappings;
using UserGroup.Entities;

namespace UserGroup.Commands.Handlers
{
    public class ChangeSpeakerHandler : CommandHandler<ChangeSpeaker>
    {
        private readonly IRepository<Speaker> repository;
        public ChangeSpeakerHandler(IRepository<Speaker> repository)
        {
            this.repository = repository;
        }

        public override void Execute(ChangeSpeaker command)
        {
            var speaker = repository.Entities.Single(s => s.Id == command.Id);
            command.MapTo(speaker);
            repository.SaveAllChanges();
        }
    }
}