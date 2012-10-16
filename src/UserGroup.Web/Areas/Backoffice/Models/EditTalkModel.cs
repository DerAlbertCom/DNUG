using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using UserGroup.Web.DataAnnotations;

namespace UserGroup.Web.Areas.Backoffice.Models
{
    public class EditTalkModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Title { get; set; }

        [Required]
        [StringLength(256)]
        [DataType(DataType.MultilineText)]
        [Wiki]
        public string Abstract { get; set; }

        [UIHint("DropDown")]
        public int MeetingId { get; set; }

        public IEnumerable<SelectListItem> MeetingSelectList { get; set; }

        [StringLength(2048)]
        [DataType(DataType.MultilineText)]
        [Wiki]
        public string Description { get; set; }
    }
}