using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Aperea.Commands;

namespace UserGroup.Commands
{
    public class AddMeeting : ICommand
    {
        [Required]
        [StringLength(128)]
        public string Title { get; set; }

        [Required]
        [StringLength(16)]
        public string Group { get; set; }
        [Required]
        [StringLength(512)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        [StringLength(512)]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime DisplayFrom { get; set; }
        public int Duration { get; set; }
        [DisplayName("Location")]
        public int LocationId { get; set; }

        [StringLength(512)]
        [DataType(DataType.Url)]
        public string RegistrationUrl { get; set; }
    }
}