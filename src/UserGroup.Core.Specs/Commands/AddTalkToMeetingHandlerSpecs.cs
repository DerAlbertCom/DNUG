using System.Linq;
using Aperea.Data;
using Machine.Fakes;
using Machine.Specifications;
using UserGroup.Commands;
using UserGroup.Commands.Handlers;
using UserGroup.Entities;
using UserGroup.Queries;
using UserGroup.Services;

namespace UserGroup.Core.Specs.Commands
{
    [Subject(typeof (AddTalkToMeetingHandler))]
    public class When_adding_a_new_talk_to_a_existing_meeting : WithSubject<AddTalkToMeetingHandler>
    {
        Establish context = () =>
        {
            meetings = TestData.GetThreeMeetings();
            speakers = TestData.GetFiveSpeakers();
            With(new BehaviorRepository<Meeting>(meetings));
            With(new BehaviorRepository<Speaker>(speakers));

            With<BehaviorCoreMapping>();
            With<BehaviorSlugGenerators>();
        };

        Because of = () =>
        {
            var command = new AddTalkToMeeting
            {
                MeetingId = meetings[1].Id,
                Title = "Dies ist der erste Talk",
                Description = "DescEin",
                Abstract = "Ab",
                SpeakerIds = new[] {speakers[2].Id,speakers[1].Id}
            };
            Subject.Execute(command);
            _specificationController.UpdateEnties(meetings, m=>m.Talks);
        };

        It should_add_a_meeting_to_the_second_meeting = () => meetings[1].Talks.Count.ShouldEqual(1);
        It should_not_add_a_meeting_to_the_first_meeting = () => meetings[0].Talks.Count.ShouldEqual(0);
        It should_not_add_a_meeting_to_the_second_meeting = () => meetings[2].Talks.Count.ShouldEqual(0);
        It should_add_two_speakers_to_the_talk = () => meetings[1].Talks.First().Speakers.Count().ShouldEqual(2);

        It should_the_added_talk_with_the_title_dies_ist_der_erste_talk =
            () => meetings[1].Talks.First().Title.ShouldEqual("Dies ist der erste Talk");

        It should_the_added_talk_with_the_description_descEins =
            () => meetings[1].Talks.First().Description.ShouldEqual("DescEin");

        It should_call_findSpeaker_with_id_10 = () => The<IFindSpeaker>().WasToldTo(f => f.Execute(speakers[2].Id));

        It should_call_findSpeaker_with_id_20 = () => The<IFindSpeaker>().WasToldTo(f => f.Execute(speakers[1].Id));

        It should_set_the_meeting_in_the_talk = () => meetings[1].Talks.First().Meeting.ShouldBeTheSameAs(meetings[1]);
        static Meeting[] meetings;

        It should_the_slug_is_dies_ist_der_erste_talk = () => meetings[1].Talks.First().Slug.ShouldEqual("dies-ist-der-erste-talk");
        static Talk talk;
        static Speaker[] speakers;
    }
}