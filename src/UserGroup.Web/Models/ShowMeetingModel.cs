using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using UserGroup.Web.Annotations;

namespace UserGroup.Web.Models
{
    public class ShowMeetingModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Slug { get; private set; }
        [Wiki]
        public string Description { get; set; }

        [Wiki]
        public string Text { get; set; }

        [DisplayName("Datum")]
        [ShortDate]
        public DateTime StartDate { get; set; }

        [DisplayName("Uhrzeit")]
        [ShortTime]
        public TimeSpan StartTime { get; set; }

        public int Duration { get; set; }

        public string LocationName { get; set; }

        [DataType(DataType.Url)]
        public string RegistrationUrl { get; set; }

        [DataType(DataType.Url)]
        public object LocationUrl { get; set; }

        public IEnumerable<MeetingDetailsTalkModel> Talks { get; set; }
    }
}