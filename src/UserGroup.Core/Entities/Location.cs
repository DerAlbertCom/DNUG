using System;
using System.ComponentModel.DataAnnotations;

namespace UserGroup.Entities
{
    public class Location : ISlug, IHasId
    {
        public Location()
        {
            Address = new Address();
        }

        public int Id { get; private set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        [StringLength(196)]
        public string Slug { get; set; }

        [StringLength(2048)]
        public string Description { get; set; }

        [StringLength(2048)]
        public string MapsUrl { get; set; }

        public void SetSlug(string slug)
        {
            this.SetSlugInternal(slug, 196);

        }

        public Address Address { get; set; }
    }
}