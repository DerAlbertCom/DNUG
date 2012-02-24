using System;
using System.Globalization;
using System.Web.Mvc;
using DotnetKoeln.STS.ActionResults;
using Microsoft.IdentityModel.Protocols.WSFederation;

namespace DotnetKoeln.STS.Controllers
{
    [Authorize]
    public class TokenController : BaseController
    {
        public ActionResult Index(string wa)
        {
            string action = wa;

            try
            {
                switch (wa)
                {
                    case WSFederationConstants.Actions.SignIn:
                        return new PassiveSignInResponseResult(HttpContext);
                    case WSFederationConstants.Actions.SignOut:
                        return new PassiveSignOutRequestResult(HttpContext);
                }

                throw new InvalidOperationException(
                    string.Format(CultureInfo.InvariantCulture,
                                  "The action '{0}' (Request.QueryString['{1}']) is unexpected. Expected actions are: '{2}' or '{3}'.",
                                  String.IsNullOrEmpty(action) ? "<EMPTY>" : action,
                                  WSFederationConstants.Parameters.Action,
                                  WSFederationConstants.Actions.SignIn,
                                  WSFederationConstants.Actions.SignOut));
            }
            catch (Exception exception)
            {
                throw new Exception(
                    "An unexpected error occurred when processing the request. See inner exception for details.",
                    exception);
            }
        }
    }
}