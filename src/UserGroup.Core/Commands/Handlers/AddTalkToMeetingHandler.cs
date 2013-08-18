using System.Linq;
using Aperea.Commands;
using Aperea.Data;
using Aperea.Infrastructure.Mappings;
using UserGroup.Entities;
using UserGroup.Queries;
using UserGroup.Services;

namespace UserGroup.Commands.Handlers
{
    public class AddTalkToMeetingHandler : CommandHandler<AddTalkToMeeting>
    {
        private readonly IRepository<Meeting> repository;
        private readonly IFindSpeaker findSpeaker;
        private readonly ISlugGenerator<Talk> generator;

        public AddTalkToMeetingHandler(IRepository<Meeting> repository, IFindSpeaker findSpeaker, ISlugGenerator<Talk> generator)
        {
            this.repository = repository;
            this.findSpeaker = findSpeaker;
            this.generator = generator;
        }

        public override void Execute(AddTalkToMeeting command)
        {
            var meeting = repository.Entities.Single(m => m.Id==command.MeetingId);
            var talk = command.MapTo<Talk>();

            generator.Generate(talk);
            talk.Meeting = meeting;
            meeting.Talks.Add(talk);

            foreach (var speakerId in command.SpeakerIds)
            {
                talk.Speakers.Add(findSpeaker.Execute(speakerId));
            }

            repository.SaveAllChanges();
        }
    }
}