﻿using System.Linq;
using Aperea;
using Aperea.Commands;
using Aperea.Data;
using Aperea.Infrastructure.Mappings;
using UserGroup.Entities;
using UserGroup.Queries;

namespace UserGroup.Commands.Handlers
{
    [UsedImplicitly]
    public sealed class AddMeetingHandler : CommandHandler<AddMeeting>
    {
        private readonly IRepository<Meeting> meetings;
        private readonly IFindLocation location;

        public AddMeetingHandler(IRepository<Meeting> meetings, IFindLocation location)
        {
            this.meetings = meetings;
            this.location = location;
        }

        public override void Execute(AddMeeting command)
        {
            var mapping = command.MapTo<Meeting>();
            mapping.Location = location.Execute(command.LocationId);
            meetings.Add(mapping);
            meetings.SaveChanges();
        }
    }
}