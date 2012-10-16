using System;
using System.ComponentModel.DataAnnotations;

namespace UserGroup.Entities
{
    public class Page : ISlug
    {
        public int Id { get; private set; }

        [Required]
        [StringLength(160)]
        public string Title { get; set; }

        [Required]
        [StringLength(192)]
        public string Slug { get; set; }

        [StringLength(1024)]
        public string Abstract { get; set; }

        [StringLength(3096)]
        public string Content { get; set; }

        public void SetSlug(string slug)
        {
            this.SetSlugInternal(slug, 192);
        }
    }
}