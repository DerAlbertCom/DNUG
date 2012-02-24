using System;
using System.Globalization;
using DotnetKoeln.STS.Services;

namespace DotnetKoeln.STS.Entities
{
    public class WebUser
    {
        WebUser()
        {
            Created = DateTime.UtcNow;
            Updated = Created;
            Modified = false;
            Username = string.Empty;
            EMail = string.Empty;
            PasswordHash = string.Empty;
            Role = Security.Role.User;
            Confirmed = false;
            Active = false;
        }

        public int Id { get; set; }

        public DateTime Created { get; private set; }
        public DateTime Updated { get; private set; }


        public bool Modified { get; private set; }

        public string Username { get; private set; }
        public string EMail { get; private set; }
        public string PasswordHash { get; private set; }
        public bool Confirmed { get; private set; }
        public bool Active { get; private set; }
        public int BounceCount { get; private set; }
        public DateTime? LastLogin { get; private set; }
        public Guid? ConfirmationKey { get; private set; }
        public string Role { get; private set; }


        public bool PasswordIsValid(string password, IHashing hashing)
        {
            return hashing.CreateHash(password, Created) == PasswordHash;
        }

        public void LoggedIn()
        {
            LastLogin = DateTime.UtcNow;
            ObjectModified();
        }

        void ObjectModified()
        {
            Updated = DateTime.UtcNow;
            Modified = false;
        }
    }
}