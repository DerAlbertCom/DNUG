using Aperea.Data;
using Machine.Fakes;
using Machine.Specifications;
using UserGroup.Commands;
using UserGroup.Commands.Handlers;
using UserGroup.Entities;

namespace UserGroup.Core.Specs.Commands
{
    [Subject(typeof (RemoveTalkFromMeetingHandler))]
    public class When_removing_a_talk_from_a_exsiting_meeting : WithSubject<RemoveTalkFromMeetingHandler>
    {
        Establish context = () =>
        {
            meetings = TestData.GetThreeMeetings();
            talks = TestData.GetFiveTalks();
            meetings[1].Talks.Add(talks[0]);
            meetings[1].Talks.Add(talks[1]);
            meetings[1].Talks.Add(talks[2]);

            meetings[0].Talks.Add(talks[3]);
            meetings[2].Talks.Add(talks[4]);

            With(new BehaviorRepository<Meeting>(meetings));

            With<BehaviorCoreMapping>();
        };

        Because of = () =>
        {
            Subject.Execute(new RemoveTalkFromMeeting(talks[1].Id, meetings[1].Id));
            _specificationController.UpdateEnties(meetings);
        };


        It should_only_two_talks_left = () => meetings[1].Talks.Count.ShouldEqual(2);

        It should_the_first_talk_in_the_meeting_present = () => meetings[1].Talks.ShouldContain(talks[0]);
        It should_the_third_talk_in_the_meeting_present = () => meetings[1].Talks.ShouldContain(talks[2]);

        It should_the_first_meeting_still_has_one_talk = () => meetings[0].Talks.Count.ShouldEqual(1);
        It should_the_third_meeting_still_has_one_talk = () => meetings[2].Talks.Count.ShouldEqual(1);

        static Meeting[] meetings;
        static Talk[] talks;
    }
}