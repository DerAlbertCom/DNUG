using System;
using System.ComponentModel.DataAnnotations;
using UserGroup.Web.DataAnnotations;

namespace UserGroup.Web.Areas.BackOffice.Models
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
        [Wiki]
        public string Vita { get; set; }
    }
}