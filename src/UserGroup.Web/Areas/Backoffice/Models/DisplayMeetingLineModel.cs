using System;
using System.ComponentModel;
using UserGroup.Web.DataAnnotations;

namespace UserGroup.Web.Areas.Backoffice.Models
{
    public class DisplayMeetingLineModel
    {
        public int Id { get; set; }

        [DisplayName("Datum")]
        [ShortDate]
        public DateTime StartDate { get; set; }

        [DisplayName("Uhrzeit")]
        [ShortTime]
        public TimeSpan StartTime { get; set; }

        [DisplayName("Beschreibung")]
        [Wiki]
        public string Description { get; set; }

        [DisplayName("Titel")]
        public string Title { get; set; }
    }
}