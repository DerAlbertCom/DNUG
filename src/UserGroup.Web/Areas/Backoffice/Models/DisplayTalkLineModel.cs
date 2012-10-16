using System;
using System.ComponentModel;
using UserGroup.Web.DataAnnotations;

namespace UserGroup.Web.Areas.Backoffice.Models
{
    public class DisplayTalkLineModel
    {
        public int Id { get; set; }

        [DisplayName("Titel")]
        public string Title { get; set; }

        [DisplayName("Treffen")]
        public string MeetingTitle{ get; set; }
    }
}