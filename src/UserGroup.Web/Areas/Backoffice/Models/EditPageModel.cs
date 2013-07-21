using System;
using System.ComponentModel.DataAnnotations;
using UserGroup.Web.DataAnnotations;

namespace UserGroup.Web.Areas.BackOffice.Models
{
    public class EditPageModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [StringLength(160)]
        public string Title { get; set; }

        [Required]
        [StringLength(192)]
        public string Slug { get; set; }

        [StringLength(1024)]
        [Wiki]
        [DataType(DataType.MultilineText)]
        public string Abstract { get; set; }

        [StringLength(3096)]
        [Wiki]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}