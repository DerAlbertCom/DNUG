using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace UserGroup.Web.Models
{
    public class MeetingDetailsTalkModel
    {
        public MeetingDetailsTalkModel()
        {
            Speakers=new Collection<SpeakerLineModel>();
        }
        public string Title { get; set; }

        [UIHint("Wiki")]
        public string Abstract { get; set; }

        [UIHint("Wiki")]
        public string Description { get; set; }

        [DataType(DataType.Url)]
        public string TalkUrl { get; set; }
        public IEnumerable<SpeakerLineModel> Speakers { get; set; }
    }
}