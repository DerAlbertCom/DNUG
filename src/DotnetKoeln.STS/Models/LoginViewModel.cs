using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DotnetKoeln.STS.Models
{
    public class LoginViewModel
    {
        [Required]
        [DisplayName("Benutzername")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Kennwort")]
        public string Password { get; set; }
    }
}