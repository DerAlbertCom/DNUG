using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UserGroup.Web.Models
{
    public class MeetingLineModel
    {
        public string Slug { get; set; }
        
        [DisplayName("Datum")]
        [UIHint("ShortDate")]
        public DateTime StartDate { get; set; }

        [DisplayName("Uhrzeit")]
        [UIHint("ShortTime")]
        public TimeSpan StartTime { get; set; }
        
        [DisplayName("Titel")]
        public string Title { get; set; }

        [DisplayName("Beschreibung")]
        [UIHint("Wiki")]
        public string Description { get; set; }

        public string MeetingDetailUrl { get; set; }
    }
}