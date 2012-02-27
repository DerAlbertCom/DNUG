using System;
using System.ComponentModel.DataAnnotations;

namespace UserGroup.Web.Areas.Backoffice.Models
{
    public class EditMeetingModel
    {
        public EditMeetingModel()
        {
            StartTime = DateTime.Now;
            DisplayFrom = DateTime.Now;
        }

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Title { get; set; }

        [StringLength(196)]
        public string Slug { get; private set; }

        [Required]
        [StringLength(16)]
        [UIHint("MeetingGroup")]
        public string Group { get; set; }

        [Required]
        [StringLength(512)]
        [DataType(DataType.MultilineText)]
        [UIHint("Wiki")]
        public string Description { get; set; }

        [StringLength(1024)]
        [DataType(DataType.MultilineText)]
        [UIHint("Wiki")]
        public string Text { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime DisplayFrom { get; set; }

        public int Duration { get; set; }

        public int LocationId { get; set; }

        [StringLength(512)]
        [DataType(DataType.Url)]
        public string RegistrationUrl { get; set; }
    }
}