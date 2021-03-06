using System;
using System.ComponentModel;
using UserGroup.Web.DataAnnotations;

namespace UserGroup.Web.Models
{
    public class MeetingLineModel
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        
        [DisplayName("Datum")]
        [ShortDate]
        public DateTime StartDate { get; set; }

        [DisplayName("Uhrzeit")]
        [ShortTime]
        public TimeSpan StartTime { get; set; }
        
        [DisplayName("Titel")]
        public string Title { get; set; }

        [DisplayName("Beschreibung")]
        [Wiki]
        public string Description { get; set; }

        public string MeetingDetailUrl { get; set; }
    }
}