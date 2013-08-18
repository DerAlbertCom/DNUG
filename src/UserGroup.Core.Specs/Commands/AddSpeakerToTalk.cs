using Aperea.Data;
using Machine.Specifications;
using Machine.Fakes;
using UserGroup.Commands;
using UserGroup.Commands.Handlers;
using UserGroup.Entities;

namespace UserGroup.Core.Specs.Commands
{
    [Behaviors]
    public class Adding_a_speaker_to_a_talk
    {

        It should_the_talk_speaker_added_to_the_second_talk = () => talks[1].Speakers.ShouldContain(speakers[1]);
        It should_only_on_speaker_is_present_in_the_second_talk = () => talks[1].Speakers.Count.ShouldEqual(1);
        It should_no_speaker_added_to_the_first_talk = () => talks[0].Speakers.Count.ShouldEqual(0);
        It should_no_speaker_added_to_the_third_talk = () => talks[2].Speakers.Count.ShouldEqual(0);

        static protected Talk[] talks;
        static protected Speaker[] speakers;
    }

    [Subject(typeof (AddSpeakerToTalkHandler))]
    public class When_adding_a_speaker_to_a_talk : WithSubject<AddSpeakerToTalkHandler>
    {
        Establish context = () =>
        {
            talks = TestData.GetThreeTalks();
            speakers = TestData.GetThreeSpeakers();
            With(new BehaviorRepository<Talk>(talks));
            With(new BehaviorRepository<Speaker>(speakers));
        };

        Because of = () => Subject.Execute(new AddSpeakerToTalk(speakers[1].Id, talks[1].Id));

        It should_the_changes_are_saved = () => The<IRepository<Talk>>().WasToldTo(r => r.SaveAllChanges());

        Behaves_like<Adding_a_speaker_to_a_talk> adding_a_speaker_to_a_talk;

        static protected Talk[] talks;
        static protected Speaker[] speakers;
    }

    [Subject(typeof(AddSpeakerToTalkHandler))]
    public class When_adding_a_speaker_to_a_talk_which_allready_contains_that_speaker : WithSubject<AddSpeakerToTalkHandler>
    {
        Establish context = () =>
        {
            talks = TestData.GetThreeTalks();
            speakers = TestData.GetThreeSpeakers();
            talks[1].Speakers.Add(speakers[1]);
            With(new BehaviorRepository<Talk>(talks));
            With(new BehaviorRepository<Speaker>(speakers));
        };

        Because of = () => Subject.Execute(new AddSpeakerToTalk(speakers[1].Id, talks[1].Id));

        It should_not_save_the_changes = () => The<IRepository<Talk>>().WasNotToldTo(r => r.SaveAllChanges());

        Behaves_like<Adding_a_speaker_to_a_talk> adding_a_speaker_to_a_talk;

        static protected Talk[] talks;
        static protected Speaker[] speakers;
    }

}