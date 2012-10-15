using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using UserGroup.Web.DataAnnotations;

namespace UserGroup.Web.Models
{
    public class ShowSpeakerModel
    {
        public string GivenName { get; set; }

        public string LastName { get; set; }

        [DataType(DataType.Url)]
        public string Homepage { get; set; }

        [Wiki]
        [DataType(DataType.MultilineText)]
        public string Vita { get; set; }

        [ReadOnly(true)]
        [HiddenInput(DisplayValue = false)]
        public string FullName
        {
            get { return string.Format("{0} {1}", GivenName, LastName); }
        }
    }
}