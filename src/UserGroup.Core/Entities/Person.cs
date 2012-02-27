using System;
using System.ComponentModel.DataAnnotations;
using UserGroup.Security;

namespace UserGroup.Entities
{
    public class Person
    {
        protected Person()
        {
            Role = Roles.User;
        }

        public Person(string loginName) : this()
        {
            LoginName = loginName;
        }

        public int Id { get; private set; }

        [Required]
        [StringLength(128)]
        public string LoginName { get; private set; }

        [Required]
        [StringLength(64)]
        public string Role { get; private set; }

        public DateTime? LastLogin { get; set; }

        public void PromoteToAdministrator()
        {
            Role = Roles.Administrator;
        }
    }
}