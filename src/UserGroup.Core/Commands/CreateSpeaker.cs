using System.ComponentModel.DataAnnotations;
using Aperea.Commands;

namespace UserGroup.Commands
{
    public class CreateSpeaker : ICommand
    {
        [Required]
        [StringLength(64)]
        public string GivenName { get; set; }

        [Required]
        [StringLength(64)]
        public string LastName { get; set; }


        [StringLength(256)]
        [DataType(DataType.Url)]
        public string Homepage { get; set; }

        [StringLength(1024)]
        [DataType(DataType.MultilineText)]
        public string Vita { get; set; }
    }
}