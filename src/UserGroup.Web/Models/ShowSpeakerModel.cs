using System.ComponentModel.DataAnnotations;

namespace UserGroup.Web.Models
{
    public class ShowSpeakerModel
    {
        public string GivenName { get; set; }

        public string LastName { get; set; }

        [DataType(DataType.Url)]
        public string Homepage { get; set; }

        [DataType(DataType.MultilineText)]
        [UIHint("Wiki")]
        public string Vita { get; set; }

        public string FullName
        {
            get { return string.Format("{0} {1}", GivenName, LastName); }
        }
    }
}