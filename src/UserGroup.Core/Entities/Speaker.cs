using System;
using System.ComponentModel.DataAnnotations;

namespace UserGroup.Entities
{
    public class Speaker : ISlug
    {
        public int Id { get; private set; }

        [Required]
        [StringLength(64)]
        public string GivenName { get; set; }

        [Required]
        [StringLength(64)]
        public string LastName { get; set; }

        [Required]
        [StringLength(196)]
        public string Slug { get; private set; }

        public void SetSlug(string slug)
        {
            this.SetSlug(slug, 196);
        }

        [StringLength(256)]
        [DataType(DataType.Url)]
        public string Homepage { get; set; }

        [StringLength(1024)]
        [DataType(DataType.MultilineText)]
        public string Vita { get; set; }

        public string FullName
        {
            get { return string.Format("{0} {1}", GivenName, LastName); }
        }
    }
}