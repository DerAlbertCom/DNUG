using Aperea.Commands;
using Aperea.Data;
using Aperea.Infrastructure.Mappings;
using UserGroup.Entities;
using UserGroup.Services;

namespace UserGroup.Commands.Handlers
{
    public class CreateSpeakerHandler : CommandHandler<CreateSpeaker>
    {
        private readonly IRepository<Speaker> repository;
        private readonly ISlugGenerator<Speaker> generator;

        public CreateSpeakerHandler(IRepository<Speaker> repository, ISlugGenerator<Speaker> generator)
        {
            this.repository = repository;
            this.generator = generator;
        }

        public override void Execute(CreateSpeaker command)
        {
            var newSpeaker = command.MapTo<Speaker>();

            generator.Generate(newSpeaker);
            repository.Add(newSpeaker);
            repository.SaveAllChanges();
        }
    }
}