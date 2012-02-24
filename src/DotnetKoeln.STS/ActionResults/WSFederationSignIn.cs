using System;
using System.Web;
using DotnetKoeln.STS.TokenService;
using Microsoft.IdentityModel.Protocols.WSFederation;
using Microsoft.IdentityModel.SecurityTokenService;
using Microsoft.IdentityModel.Web;

namespace DotnetKoeln.STS.ActionResults
{
    internal class WSFederationSignIn
    {
        readonly HttpContextBase httpContext;

        public WSFederationSignIn(HttpContextBase httpContext)
        {
            this.httpContext = httpContext;
        }

        public SignInResponseMessage CreateMessage()
        {
            var user = httpContext.User;

            var requestMessage = (SignInRequestMessage) WSFederationMessage.CreateFromUri(httpContext.Request.Url);

            if (user != null && user.Identity.IsAuthenticated)
            {
                SecurityTokenService sts =
                    new StotaxSecurityTokenService(StotaxSecurityTokenServiceConfiguration.Current);
                SignInResponseMessage responseMessage =
                    FederatedPassiveSecurityTokenServiceOperations.ProcessSignInRequest(requestMessage, user, sts);
                return responseMessage;
            }
            throw new UnauthorizedAccessException();
        }
    }
}