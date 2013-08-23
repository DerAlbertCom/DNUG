using System;
using System.Linq;
using Aperea.Data;
using Machine.Fakes;
using Machine.Specifications;
using UserGroup.Commands;
using UserGroup.Commands.Handlers;
using UserGroup.Entities;

namespace UserGroup.Core.Specs.Commands
{
    [Subject(typeof (DeleteMeetingHandler))]
    public class When_deleting_one_meeting_out_of_two : WithSubject<DeleteMeetingHandler>
    {
        Establish context = () =>
        {
            meetings = TestData.GetThreeMeetings();
            With(new BehaviorRepository<Meeting>(meetings));
            id0 = meetings[0].Id;
            id1 = meetings[1].Id;
        };

        Because of = () => Subject.Execute(new DeleteMeeting(meetings[1].Id));

        It should_remove_the_second_meeting =
            () => The<IRepository<Meeting>>().Entities.SingleOrDefault(e => e.Id == id1).ShouldBeNull();

        It should_not_remove_the_first_meeting =
            () => The<IRepository<Meeting>>().Entities.SingleOrDefault(e => e.Id == id0).ShouldNotBeNull();

        It should_save_all_the_changes = () => The<IRepository<Meeting>>().WasToldTo(r => r.SaveAllChanges());


        static Meeting[] meetings;
        static int id0;
        static int id1;
    }


    [Subject(typeof (DeleteMeetingHandler))]
    public class When_deleting_an_unknown_meeting_out_of_two : WithSubject<DeleteMeetingHandler>
    {
        Establish context = () =>
        {
            meetings =TestData.GetThreeMeetings().Take(2).ToArray();
            With(new BehaviorRepository<Meeting>(meetings));
            id0 = meetings[0].Id;
            id1 = meetings[1].Id;
        };

        Because of = () => exception = Catch.Exception(() => Subject.Execute(new DeleteMeeting(2345)));

        It should_throw_an_invalid_operation_exception = () => exception.ShouldBeOfType<InvalidOperationException>();

        It should_not_remove_the_second_meeting =
            () => The<IRepository<Meeting>>().Entities.SingleOrDefault(e => e.Id ==id1).ShouldNotBeNull();

        It should_not_remove_the_first_meeting =
            () => The<IRepository<Meeting>>().Entities.SingleOrDefault(e => e.Id == id0).ShouldNotBeNull();

        It should_not_save_all_the_changes = () => The<IRepository<Meeting>>().WasNotToldTo(r => r.SaveAllChanges());


        static Meeting[] meetings;
        static Exception exception;
        static int id0;
        static int id1;
    }
}