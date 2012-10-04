using System.ComponentModel.DataAnnotations;
using UserGroup.Web.Annotations;

namespace UserGroup.Web.Models
{
    public class ShowSpeakerModel
    {
        public string GivenName { get; set; }

        public string LastName { get; set; }

        [DataType(DataType.Url)]
        public string Homepage { get; set; }

        [DataType(DataType.MultilineText)]
        [Wiki]
        public string Vita { get; set; }

        public string FullName
        {
            get { return string.Format("{0} {1}", GivenName, LastName); }
        }
    }
}