﻿using Aperea.Data;
using Machine.Fakes;
using Machine.Specifications;
using UserGroup.Commands;
using UserGroup.Commands.Handlers;
using UserGroup.Entities;
using UserGroup.Queries;

namespace UserGroup.Core.Specs.Commands
{
    [Subject(typeof (ChangeMeetingHandler))]
    public class When_editing_the_second_meeting_out_of_three_meetings : WithSubject<ChangeMeetingHandler>
    {
        Establish context = () =>
        {
            meetings = TestData.GetThreeMeetings();
            With(new BehaviorRepository<Meeting>(meetings));
            With<BehaviorCoreMapping>();
        };

       
        Because of = () => Subject.Execute(new ChangeMeeting
        {
            Id = meetings[1].Id,
            Title = "ChangeZwei",
            Description = "ChangeZweiDesc",
            Slug = meetings[1].Slug,
            Group = meetings[1].Group,
            LocationId = 34,
            DisplayFrom = meetings[1].DisplayFrom,
            StartTime = meetings[1].StartTime
        });


        It should_the_second_meeting_has_the_title_changeZwei = () => meetings[1].Title.ShouldEqual("ChangeZwei");

        It should_the_second_meeting_has_the_description_changeZweiDesc =
            () => meetings[1].Description.ShouldEqual("ChangeZweiDesc");

        It should_not_change_the_title_of_the_first_meeting = () => meetings[0].Title.ShouldEqual("Eins");

        It should_not_change_the_description_of_the_third_meeting =
            () => meetings[2].Description.ShouldEqual("DreiDesc");

        It should_execute_findLocation = () => The<IFindLocation>().WasToldTo(fl => fl.Execute(34));

        It should_save_all_the_changes = () => The<IRepository<Meeting>>().WasToldTo(r => r.SaveAllChanges());

        static Meeting[] meetings;
    }
}