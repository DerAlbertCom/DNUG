using System.Linq;
using Aperea.Data;
using Machine.Fakes;
using Machine.Specifications;
using UserGroup.Commands;
using UserGroup.Commands.Handlers;
using UserGroup.Entities;
using UserGroup.Queries;

namespace UserGroup.Core.Specs.Commands
{
    [Subject(typeof (AddTalkToMeetingHandler))]
    public class When_adding_a_new_talk_to_a_existing_meeting : WithSubject<AddTalkToMeetingHandler>
    {
        Establish context = () =>
        {
            meetings = TestData.GetThreeMeetings();

            With<BehaviorCoreMapping>();
            With(new BehaviorRepository<Meeting>(meetings));
        };

        Because of = () =>
        {
            var command = new AddTalkToMeeting
            {
                MeetingId = meetings[1].Id,
                Title = "TalkEins",
                Description = "DescEin",
                SpeakerIds = new[] {10, 20}
            };
            Subject.Execute(command);
        };

        It should_add_a_meeting_to_the_second_meeting = () => meetings[1].Talks.Count.ShouldEqual(1);
        It should_not_add_a_meeting_to_the_first_meeting = () => meetings[0].Talks.Count.ShouldEqual(0);
        It should_not_add_a_meeting_to_the_second_meeting = () => meetings[2].Talks.Count.ShouldEqual(0);
        It should_add_two_speakers_to_the_talk = () => meetings[1].Talks.First().Speakers.Count().ShouldEqual(2);
        It should_save_changes = () => The<IRepository<Meeting>>().WasToldTo(r => r.SaveAllChanges());

        It should_the_added_talk_with_the_title_talkEins =
            () => meetings[1].Talks.First().Title.ShouldEqual("TalkEins");

        It should_the_added_talk_with_the_description_descEins =
            () => meetings[1].Talks.First().Description.ShouldEqual("DescEin");

        It should_call_findSpeaker_with_id_10 = () => The<IFindSpeaker>().WasToldTo(f => f.Execute(10));

        It should_call_findSpeaker_with_id_20 = () => The<IFindSpeaker>().WasToldTo(f => f.Execute(20));

        It should_set_the_meeting_in_the_talk = () => meetings[1].Talks.First().Meeting.ShouldBeTheSameAs(meetings[1]);
        static Meeting[] meetings;
    }
}