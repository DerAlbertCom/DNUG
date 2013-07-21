using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using UserGroup.Web.DataAnnotations;

namespace UserGroup.Web.Areas.BackOffice.Models
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
        public string Group { get; set; }

        [Required]
        [StringLength(512)]
        [DataType(DataType.MultilineText)]
        [Wiki]
        public string Description { get; set; }

        [StringLength(1024)]
        [DataType(DataType.MultilineText)]
        [Wiki]
        public string Text { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime DisplayFrom { get; set; }

        public int Duration { get; set; }

        [UIHint("DropDown")]
        [DisplayName("Location")]
        public int LocationId { get; set; }

        public IEnumerable<SelectListItem> LocationSelectList { get; set; }

        [StringLength(512)]
        [DataType(DataType.Url)]
        public string RegistrationUrl { get; set; }
    }
}