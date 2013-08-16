using System.ComponentModel.DataAnnotations;

namespace UserGroup.Commands
{
    public class EditMeeting : AddMeeting
    {
         public int Id { get; set; }
         [StringLength(196)]
         public string Slug { get; private set; }
    }
}