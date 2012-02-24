using System;
using System.Web;
using System.Web.Mvc;
using Microsoft.IdentityModel.Protocols.WSFederation;

namespace DotnetKoeln.STS.ActionResults
{
    public class PassiveSignInResponseResult : FileResult
    {
        readonly SignInResponseMessage message;

        public PassiveSignInResponseResult(HttpContextBase context) : base("text/html")
        {
            message = new WSFederationSignIn(context).CreateMessage();
        }

        protected override void WriteFile(HttpResponseBase response)
        {
            message.Write(response.Output);
        }
    }
}