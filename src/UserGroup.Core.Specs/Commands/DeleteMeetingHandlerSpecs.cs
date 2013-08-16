using System;
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
            meetings = new[]
            {
                new Meeting {Title = "Eins", Description = "EinsDesc"},
                new Meeting {Title = "Zwei", Description = "ZweiDesc"},
                new Meeting {Title = "Drei", Description = "DreiDesc"}
            };
            With(new BehaviorRepository<Meeting>(meetings));
        };

        Because of = () => Subject.Execute(new DeleteMeeting(meetings[1].Id));

        It should_remove_the_second_meeting = () => The<IRepository<Meeting>>().WasToldTo(r => r.Remove(meetings[1]));

        It should_not_remove_the_first_meeting =
            () => The<IRepository<Meeting>>().WasNotToldTo(r => r.Remove(meetings[0]));

        It should_save_all_changes = () => The<IRepository<Meeting>>().WasToldTo(r => r.SaveAllChanges());

        static Meeting[] meetings;
    }


    [Subject(typeof (DeleteMeetingHandler))]
    public class When_deleting_an_unknown_meeting_out_of_two : WithSubject<DeleteMeetingHandler>
    {
        Establish context = () =>
        {
            meetings = new[]
            {
                new Meeting {Title = "Foo"},
                new Meeting {Title = "Bar"}
            };
            With(new BehaviorRepository<Meeting>(meetings));
        };

        Because of = () => exception = Catch.Exception(() => Subject.Execute(new DeleteMeeting(2345)));

        It should_throw_an_invalid_operation_exception = () => exception.ShouldBeOfType<InvalidOperationException>();

        It should_not_remove_the_second_meeting =
            () => The<IRepository<Meeting>>().WasNotToldTo(r => r.Remove(meetings[1]));

        It should_not_remove_the_first_meeting =
            () => The<IRepository<Meeting>>().WasNotToldTo(r => r.Remove(meetings[0]));

        It should_not_save_all_changes = () => The<IRepository<Meeting>>().WasNotToldTo(r => r.SaveAllChanges());

        static Meeting[] meetings;
        static Exception exception;
    }
}