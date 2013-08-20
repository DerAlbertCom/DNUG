using System;
using System.Linq;
using System.Linq.Expressions;
using Aperea.Data;
using Machine.Specifications;
using Machine.Fakes;
using UserGroup.Commands;
using UserGroup.Commands.Handlers;
using UserGroup.Entities;

namespace UserGroup.Core.Specs.Commands
{
    public static class UpdateEntitiesExtensions
    {
        public static void UpdateEnties<T,TProperty>(this IFakeAccessor accessor, T[] entities, Expression<Func<T, TProperty>> includeExpression) where T : class, IHasId
        {
            for (int i = 0; i < entities.Length; i++)
            {
                var id = entities[i].Id;
                entities[i] = accessor.The<IRepository<T>>().Include(includeExpression).SingleOrDefault(e => e.Id == id);
            }
        }

          public static void UpdateEnties<T>(this IFakeAccessor accessor, T[] entities) where T : class, IHasId
        {
            for (int i = 0; i < entities.Length; i++)
            {
                var id = entities[i].Id;
                entities[i] = accessor.The<IRepository<T>>().Entities.SingleOrDefault(e => e.Id == id);
            }
        }
    }


    [Subject(typeof (AddSpeakerToTalkHandler))]
    public class When_adding_a_speaker_to_a_talk : WithSubject<AddSpeakerToTalkHandler>
    {
        Establish context = () =>
        {
            talks = TestData.GetFiveTalks();
            speakers = TestData.GetFiveSpeakers();
            With(new BehaviorRepository<Talk>(talks));
            With(new BehaviorRepository<Speaker>(speakers));
        };

        Because of = () =>
        {
            Subject.Execute(new AddSpeakerToTalk(speakers[1].Id, talks[1].Id));
            _specificationController.UpdateEnties(talks, t => t.Speakers);
            _specificationController.UpdateEnties(speakers);
        };

        It should_only_on_speaker_is_present_in_the_second_talk = () => talks[1].Speakers.Count.ShouldEqual(1);
        It should_no_speaker_added_to_the_first_talk = () => talks[0].Speakers.Count.ShouldEqual(0);
        It should_no_speaker_added_to_the_third_talk = () => talks[2].Speakers.Count.ShouldEqual(0);
        It should_the_talk_speaker_added_to_the_second_talk = () => talks[1].Speakers.ShouldContain(speakers[1]);


        static protected Talk[] talks;
        static protected Speaker[] speakers;
    }

    [Subject(typeof(AddSpeakerToTalkHandler))]
    public class When_adding_a_speaker_to_a_talk_which_allready_contains_that_speaker : WithSubject<AddSpeakerToTalkHandler>
    {
        Establish context = () =>
        {

            talks = TestData.GetFiveTalks();
            speakers = TestData.GetFiveSpeakers();
            talks[1].Speakers.Add(speakers[1]);
            With(new BehaviorRepository<Talk>(talks));
            With(new BehaviorRepository<Speaker>(speakers));
        };

        Because of = () =>
        {
            Subject.Execute(new AddSpeakerToTalk(speakers[1].Id, talks[1].Id));
            _specificationController.UpdateEnties(talks, t => t.Speakers);
            _specificationController.UpdateEnties(speakers);
        };

        It should_no_speaker_added_to_the_first_talk = () => talks[0].Speakers.Count.ShouldEqual(0);
        It should_no_speaker_added_to_the_third_talk = () => talks[2].Speakers.Count.ShouldEqual(0);
        It should_the_talk_speaker_added_to_the_second_talk = () => talks[1].Speakers.ShouldContain(speakers[1]);
        It should_only_on_speaker_is_present_in_the_second_talk = () => talks[1].Speakers.Count.ShouldEqual(1);

        static Talk[] talks;
        static Speaker[] speakers;
    }

}