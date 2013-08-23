using System;
using System.Linq;
using Aperea.Data;
using Machine.Specifications;
using Machine.Fakes;
using UserGroup.Commands;
using UserGroup.Commands.Handlers;
using UserGroup.Entities;

namespace UserGroup.Core.Specs.Commands
{
    [Subject(typeof (CreateSpeakerHandler))]
    public class When_a_speaker_is_created : WithSubject<CreateSpeakerHandler>
    {
        Establish context = () =>
        {
            speakers = TestData.GetFiveSpeakers();
            With(new BehaviorRepository<Speaker>(speakers));
            With<BehaviorCoreMapping>();
            With<BehaviorSlugGenerators>();
        };

        Because of = () =>
        {
            var command = new CreateSpeaker
            {
                GivenName = "Fred",
                LastName = "Fish",
                Vita = Guid.NewGuid().ToString()
            };
            Subject.Execute(command);
            newSpeaker = The<IRepository<Speaker>>().Entities.Single(s => s.Vita == command.Vita);
        };


        It should_the_givenName_is_fred = () => newSpeaker.GivenName.ShouldEqual("Fred");
        It should_the_lastName_is_fish = () => newSpeaker.LastName.ShouldEqual("Fish");

        It should_has_the_slug_fred_fish = () => newSpeaker.Slug.ShouldEqual("fred-fish");

        It should_save_all_the_changes = () => The<IRepository<Speaker>>().WasToldTo(r => r.SaveAllChanges());

        static Speaker[] speakers;
        static Speaker newSpeaker;
    }
}