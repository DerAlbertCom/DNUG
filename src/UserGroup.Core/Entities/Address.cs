using System;
using System.ComponentModel.DataAnnotations;

namespace UserGroup.Entities
{
    public class Address
    {
        [StringLength(128)]
        public string Street { get; set; }

        [StringLength(6)]
        public string ZipCode { get; set; }

        [StringLength(128)]
        public string City { get; set; }

        [StringLength(128)]
        [DataType(DataType.Url)]
        public string MapsUrl { get; set; }
    }
}