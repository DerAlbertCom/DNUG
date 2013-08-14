using System;
using Aperea;

namespace UserGroup.Api.Models
{
    [UsedImplicitly]
    public sealed class DisplayMeetingLineModel
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public TimeSpan StartTime { get; set; }

        public string Description { get; set; }

        public string Title { get; set; }
    }
}