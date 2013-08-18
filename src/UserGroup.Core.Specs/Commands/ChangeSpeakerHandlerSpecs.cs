using System.Linq;
using Aperea.Data;
using Machine.Fakes.Sdk;
using Machine.Specifications;
using Machine.Fakes;
using UserGroup.Commands;
using UserGroup.Commands.Handlers;
using UserGroup.Entities;

namespace UserGroup.Core.Specs.Commands
{
    [Subject(typeof (ChangeSpeakerHandler))]
    public class When_changing_the_speaker_data : WithSubject<ChangeSpeakerHandler>
    {
        Establish context = () => {  };

        Because of = () =>
        {
            speakers = TestData.GetFiveSpeakers();
            With(new BehaviorRepository<Speaker>(speakers));
            With<BehaviorCoreMapping>();

            var command = new ChangeSpeaker
            {
                Id = speakers[2].Id,
                GivenName = "Hover",
                LastName = "Craft",
                Slug = "foo-bar"
            };
            Subject.Execute(command);
            speaker = The<IRepository<Speaker>>().Entities.Single(s => s.Id == command.Id);
        };

        It should_save_the_changes = () => The<IRepository<Speaker>>().WasToldTo(r=>r.SaveAllChanges());
        It should_have_hover_as_given_name=()=>speaker.GivenName.ShouldEqual("Hover");
        It should_have_craft_as_last_name=()=>speaker.LastName.ShouldEqual("Craft");
        It should_have_foo_bar_as_slug = ()=>speaker.Slug.ShouldEqual("foo-bar");
        static Speaker[] speakers;
        static Speaker speaker;
    }
}