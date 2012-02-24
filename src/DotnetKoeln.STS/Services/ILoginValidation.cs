using System.Linq;
using DotnetKoeln.STS.Data;
using DotnetKoeln.STS.Entities;

namespace DotnetKoeln.STS.Services
{
    public interface ILoginValidation
    {
        WebUser ValidateUser(string username, string password);
    }

    public class LoginValidation : ILoginValidation
    {
        readonly IHashing hashing;

        public LoginValidation(IHashing hashing)
        {
            this.hashing = hashing;
        }

        public WebUser ValidateUser(string username, string password)
        {
            using (var db = new StsContext())
            {
                var webUser = db.WebUsers.SingleOrDefault(w => w.Username == username);
                if (webUser != null)
                {
                    return webUser;
                }
            }
            return null;
        }
    }
}