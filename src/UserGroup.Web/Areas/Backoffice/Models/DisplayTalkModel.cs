using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using UserGroup.Web.DataAnnotations;

namespace UserGroup.Web.Areas.Backoffice.Models
{
    public class DisplayTalkModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public string Title { get; set; }


        [Wiki]
        public string Abstract { get; set; }

        [Wiki]
        public string Description { get; set; }

        public string MeetingTitle { get; set; }

        public IEnumerable<DisplaySpeakerLineModel> Speakers { get; set; }

        public IEnumerable<SelectListItem> SpeakerSelectList { get; set; } 
    }
}