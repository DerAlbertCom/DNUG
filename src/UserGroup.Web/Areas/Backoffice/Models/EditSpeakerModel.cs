using System;
using System.ComponentModel.DataAnnotations;

namespace UserGroup.Web.Areas.Backoffice.Models
{
    public class EditSpeakerModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [StringLength(64)]
        public string GivenName { get; set; }

        [Required]
        [StringLength(64)]
        public string LastName { get; set; }

        public string Fullname
        {
            get { return LastName + ", " + GivenName; }
        }

        [StringLength(256)]
        [DataType(DataType.Url)]
        public string Homepage { get; set; }

        [StringLength(1024)]
        [DataType(DataType.MultilineText)]
        [UIHint("Wiki")]
        public string Vita { get; set; }
    }
}