using Aperea.Data;
using Machine.Fakes;
using Machine.Specifications;
using UserGroup.Commands;
using UserGroup.Commands.Handlers;
using UserGroup.Entities;
using UserGroup.Queries;

namespace UserGroup.Core.Specs.Commands
{
    [Subject(typeof (AddMeetingHandler))]
    public class AddMeetingHandlerSpecs : WithSubject<AddMeetingHandler>
    {
        Establish content = () =>
        {
            With<BehaviorCoreMapping>();
            command = new AddMeeting()
            {
                Title = "Der Title",
                LocationId = 4711
            };
            
            The<IRepository<Meeting>>()
                .WhenToldTo(r => r.Add(Param.IsAny<Meeting>()))
                .Callback<Meeting>(m => meeting = m);
        };

        Because of = () => Subject.Execute(command);

        It should_add_the_meeting_to_the_repository =
            () => The<IRepository<Meeting>>().WasToldTo(r => r.Add(Param.IsAny<Meeting>()));

        It should_call_the_findLocation_with_id_4711 = () => The<IFindLocation>().WasToldTo(fl => fl.Execute(4711));

        It should_save_change_to_the_repository =
            () => The<IRepository<Meeting>>().WasToldTo(r => r.SaveChanges());

        It should_have_the_der_title_in_the_creating_meeting = () => meeting.Title.ShouldEqual("Der Title");

        static AddMeeting command;
        static Meeting meeting;
    }
}