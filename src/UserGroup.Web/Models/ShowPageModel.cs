using System.ComponentModel.DataAnnotations;
using UserGroup.Web.DataAnnotations;

namespace UserGroup.Web.Models
{
    public class ShowPageModel
    {
        public string Title { get; set; }

        public string PageUrl { get; set; }

        [Wiki]
        [DataType(DataType.MultilineText)]
        public string Abstract { get; set; }

        [Wiki]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; } 
    }
}