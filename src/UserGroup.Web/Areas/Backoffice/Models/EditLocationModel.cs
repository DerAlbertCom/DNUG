using System;
using System.ComponentModel.DataAnnotations;
using UserGroup.Entities;
using UserGroup.Web.DataAnnotations;

namespace UserGroup.Web.Areas.BackOffice.Models
{
    public class EditLocationModel
    {
        public EditLocationModel()
        {
            Address=new Address();
        }
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public Address Address { get; set; }

        [StringLength(2048)]
        [DataType(DataType.MultilineText)]
        [Wiki]
        public string Description { get; set; }

        [StringLength(2048)]
        public string MapsUrl { get; set; }
    }
}