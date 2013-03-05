using System.Linq;
using Aperea.Data;
using Microsoft.IdentityModel.Claims;
using Microsoft.Practices.ServiceLocation;
using UserGroup.Entities;

namespace UserGroup.Web.Security
{
    public class UserGroupClaimsAuthenticationManager : ClaimsAuthenticationManager
    {
        public override IClaimsPrincipal Authenticate(string resourceName, IClaimsPrincipal incomingPrincipal)
        {
            if (incomingPrincipal == null || !incomingPrincipal.Identity.IsAuthenticated)
                return incomingPrincipal;

            var identity = (ClaimsIdentity) incomingPrincipal.Identity;
            var claims = identity.Claims;
            var person = FindPerson(identity.Name);
            if (person != null)
            {
                claims.Add(new Claim(ClaimTypes.Role, person.Role));
            }
            return incomingPrincipal;
        }

        Person FindPerson(string name)
        {
            var repository = ServiceLocator.Current.GetInstance<IRepository<Person>>();
            return repository.Entities.SingleOrDefault(p => p.LoginName == name);
        }
    }
}