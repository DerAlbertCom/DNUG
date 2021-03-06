﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace UserGroup.Entities
{
    public class Meeting : ISlug, IHasLocation, IHasId
    {
        public Meeting()
        {
            DisplayFrom = DateTime.UtcNow;
            StartTime = DateTime.UtcNow;
            Talks = new Collection<Talk>();
        }

        public int Id { get; private set; }

        [Required]
        [StringLength(128)]
        public string Title { get; set; }

        [Required]
        [StringLength(196)]
        public string Slug { get; set; }

        public void SetSlug(string slug)
        {
            this.SetSlugInternal(slug, 196);

        }


        [Required]
        [StringLength(16)]
        public string Group { get; set; }

        [Required]
        [StringLength(512)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [StringLength(1024)]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime DisplayFrom { get; set; }

        public int Duration { get; set; }

        public Location Location { get; set; }

        [DataType(DataType.Url)]
        [StringLength(512)]
        public string RegistrationUrl { get; set; }

        public ICollection<Talk> Talks { get; private set; }
    }
}