using Aperea.Data;
using Machine.Specifications;
using Machine.Fakes;
using UserGroup.Commands;
using UserGroup.Commands.Handlers;
using UserGroup.Entities;

namespace UserGroup.Core.Specs.Commands
{
    [Subject(typeof (ChangeTalkHandler))]
    public class When_changing_an_existing_talk_with_speakers : WithSubject<ChangeTalkHandler>
    {
        Establish context = () =>
        {
            talks = TestData.GetFiveTalks();
            speakers = TestData.GetFiveSpeakers();
            talks[1].Speakers.Add(speakers[0]);
            talks[1].Speakers.Add(speakers[2]);

            With(new BehaviorRepository<Talk>(talks));
            With(new BehaviorRepository<Speaker>(speakers));

            With<BehaviorCoreMapping>();
        };

        Because of = () =>
        {

            var command = new ChangeTalk
            {
                Id=talks[1].Id,
                Title = "ChangedTitleZwei",
                Abstract = "foo",
                Description = "ChangedDescZwei",
                Slug = "changetitlezwei",
                SpeakerIds = new []{speakers[3].Id,speakers[4].Id,speakers[2].Id}
            };

            Subject.Execute(command);
            _specificationController.UpdateEnties(talks,t=>t.Speakers);
        };


        It should_the_title_is_changedTitleZwei = () => talks[1].Title.ShouldEqual("ChangedTitleZwei");

        It should_the_description_is_changeDescZwei = () => talks[1].Description.ShouldEqual("ChangedDescZwei");

        It should_only_the_speaker_in_the_command =
            () => talks[1].Speakers.ShouldContainOnly(new[] {speakers[3], speakers[4], speakers[2]});

        It should_save_all_the_changes = () => The<IRepository<Talk>>().WasToldTo(r => r.SaveAllChanges());

        static Talk[] talks;
        static Speaker[] speakers;
    }
}