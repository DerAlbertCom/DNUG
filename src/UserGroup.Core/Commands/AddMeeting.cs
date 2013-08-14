using System;
using Aperea.Commands;

namespace UserGroup.Commands
{
    public class AddMeeting : ICommand
    {
        public string Title { get; set; }
        public string Group { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime DisplayFrom { get; set; }
        public int Duration { get; set; }
        public int LocationId { get; set; }
        public string RegistrationUrl { get; set; }
    }
}