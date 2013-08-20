using System.Security.Principal;
using Aperea.Data;
using Machine.Specifications;
using Machine.Fakes;
using UserGroup.Commands;
using UserGroup.Commands.Handlers;
using UserGroup.Entities;
using UserGroup.Services;

namespace UserGroup.Core.Specs.Commands
{
    [Subject(typeof (RemoveSpeakerFromTalkHandler))]
    public class When_remove_the_second_speaker_from_a_talk : WithSubject<RemoveSpeakerFromTalkHandler>
    {
        Establish context = () =>
        {
            talks = TestData.GetFiveTalks();
            speakers = TestData.GetFiveSpeakers();
            talks[0].Speakers.Add(speakers[3]);
            talks[1].Speakers.Add(speakers[0]);
            talks[1].Speakers.Add(speakers[1]);
            talks[1].Speakers.Add(speakers[2]);
            talks[2].Speakers.Add(speakers[4]);
            With(new BehaviorRepository<Talk>(talks));
        };

        Because of = () =>
        {
            Subject.Execute(new RemoveSpeakerFromTalk(speakers[1].Id, talks[1].Id));
            _specificationController.UpdateEnties(talks,t=>t.Speakers);
        };

        It should_the_first_talk_have_one_speaker = () => talks[0].Speakers.Count.ShouldEqual(1);
        It should_the_third_talk_have_one_speaker = () => talks[2].Speakers.Count.ShouldEqual(1);
        It should_the_second_talk_have_two_speaker = () => talks[1].Speakers.Count.ShouldEqual(2);
        It should_the_first_speaker_present_in_the_second_talk = () => talks[1].Speakers.ShouldContain(speakers[0]);
        It should_the_third_speaker_present_in_the_second_talk = () => talks[1].Speakers.ShouldContain(speakers[2]);

        static Talk[] talks;
        static Speaker[] speakers;
    }
}