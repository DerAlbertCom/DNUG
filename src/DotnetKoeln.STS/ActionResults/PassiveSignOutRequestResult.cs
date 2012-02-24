using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.IdentityModel.Protocols.WSFederation;
using Microsoft.IdentityModel.Web;

namespace DotnetKoeln.STS.ActionResults
{
    public class PassiveSignOutRequestResult : RedirectResult
    {
        public PassiveSignOutRequestResult(HttpContextBase httpContext)
            : base(GetRedirectUrl(httpContext))
        {
        }

        static string GetRedirectUrl(HttpContextBase context)
        {
            var message = (SignOutRequestMessage) WSFederationMessage.CreateFromUri(context.Request.Url);
            var user = context.User;

            if (user != null && user.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
                DeleteSessionTokenCookie();
            }
            if (string.IsNullOrWhiteSpace(message.Reply))
            {
                return message.Reply;
            }
            return "~/";
        }

        static void DeleteSessionTokenCookie()
        {
            var authenticationModule = FederatedAuthentication.SessionAuthenticationModule;
            if (authenticationModule != null)
                authenticationModule.DeleteSessionTokenCookie();
        }
    }
}