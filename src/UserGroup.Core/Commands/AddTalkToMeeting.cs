﻿using System.ComponentModel.DataAnnotations;
using Aperea.Commands;

namespace UserGroup.Commands
{
    public class AddTalkToMeeting : ICommand
    {
        [Required]
        [StringLength(128)]
        public string Title { get; set; }

        [Required]
        [StringLength(256)]
        [DataType(DataType.MultilineText)]
        public string Abstract { get; set; }

        [UIHint("DropDown")]
        public int MeetingId { get; set; }

        [StringLength(2048)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public int[] SpeakerIds { get; set; }
    }
}