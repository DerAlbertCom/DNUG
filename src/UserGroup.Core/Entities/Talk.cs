using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace UserGroup.Entities
{
    public class Talk : ISlug, IHasMeeting, IHasId
    {
        public Talk()
        {
            Speakers = new Collection<Speaker>();
        }

        public int Id { get; private set; }

        [Required]
        [StringLength(128)]
        public string Title { get; set; }

        [Required]
        [StringLength(196)]
        public string Slug { get;  set; }

        public void SetSlug(string slug)
        {
            this.SetSlugInternal(slug,196);
        }

        [Required]
        [StringLength(256)]
        [DataType(DataType.MultilineText)]
        public string Abstract { get; set; }

        [StringLength(2048)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public Meeting Meeting { get; set; }

        public virtual ICollection<Speaker> Speakers { get; private set; }
    }
}