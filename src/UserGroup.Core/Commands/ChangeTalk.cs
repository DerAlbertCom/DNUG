using System.ComponentModel.DataAnnotations;

namespace UserGroup.Commands
{
    public class ChangeTalk : AddTalkToMeeting
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(196)]
        public string Slug { get; set; }
    }
}