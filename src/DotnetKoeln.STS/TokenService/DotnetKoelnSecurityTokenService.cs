using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Web.Configuration;
using Aperea.Identity;
using Aperea.Identity.Settings;
using DotnetKoeln.STS.Data;
using DotnetKoeln.STS.Entities;
using DotnetKoeln.STS.Settings;
using Microsoft.IdentityModel.Claims;
using Microsoft.IdentityModel.Configuration;
using Microsoft.IdentityModel.Protocols.WSTrust;
using Microsoft.IdentityModel.SecurityTokenService;
using Microsoft.Practices.ServiceLocation;

namespace DotnetKoeln.STS.TokenService
{
    public class DotnetKoelnSecurityTokenService : SecurityTokenService
    {
        // TODO: Set enableAppliesToValidation to true to enable only the RP Url's specified in the PassiveRedirectBasedClaimsAwareWebApps array to get a token from this STS
        static bool enableAppliesToValidation = false;

        // TODO: Add relying party Url's that will be allowed to get token from this STS
        static readonly string[] PassiveRedirectBasedClaimsAwareWebApps = {
                                                                              /*"https://localhost/PassiveRedirectBasedClaimsAwareWebApp"*/
                                                                          };

        /// <summary>
        /// Creates an instance of StotaxSecurityTokenService.
        /// </summary>
        /// <param name="configuration">The SecurityTokenServiceConfiguration.</param>
        public DotnetKoelnSecurityTokenService(SecurityTokenServiceConfiguration configuration)
            : base(configuration)
        {
        }

        /// <summary>
        /// Validates appliesTo and throws an exception if the appliesTo is null or contains an unexpected address.
        /// </summary>
        /// <param name="appliesTo">The AppliesTo value that came in the RST.</param>
        /// <exception cref="ArgumentNullException">If 'appliesTo' parameter is null.</exception>
        /// <exception cref="InvalidRequestException">If 'appliesTo' is not valid.</exception>
        void ValidateAppliesTo(EndpointAddress appliesTo)
        {
            if (appliesTo == null)
            {
                throw new ArgumentNullException("appliesTo");
            }

            // TODO: Enable AppliesTo validation for allowed relying party Urls by setting enableAppliesToValidation to true. By default it is false.
            if (enableAppliesToValidation)
            {
                bool validAppliesTo = false;
                foreach (string rpUrl in PassiveRedirectBasedClaimsAwareWebApps)
                {
                    if (appliesTo.Uri.Equals(new Uri(rpUrl)))
                    {
                        validAppliesTo = true;
                        break;
                    }
                }

                if (!validAppliesTo)
                {
                    throw new InvalidRequestException(String.Format("The 'appliesTo' address '{0}' is not valid.",
                                                                    appliesTo.Uri.OriginalString));
                }
            }
        }

        protected override Scope GetScope(IClaimsPrincipal principal, RequestSecurityToken request)
        {
            ValidateAppliesTo(request.AppliesTo);

            Scope scope = new Scope(request.AppliesTo.Uri.OriginalString,
                                    SecurityTokenServiceConfiguration.SigningCredentials);

            var settings = ServiceLocator.Current.GetInstance<IEncryptionSettings>();
            if (settings.Encrypt)
            {
                // Important note on setting the encrypting credentials.
                // In a production deployment, you would need to select a certificate that is specific to the RP that is requesting the token.
                // You can examine the 'request' to obtain information to determine the certificate to use.
                scope.EncryptingCredentials = new X509EncryptingCredentials(settings.Certificate);
            }
            else
            {
                // If there is no encryption certificate specified, the STS will not perform encryption.
                // This will succeed for tokens that are created without keys (BearerTokens) or asymmetric keys.  
                scope.TokenEncryptionRequired = false;
            }

            // Set the ReplyTo address for the WS-Federation passive protocol (wreply). This is the address to which responses will be directed. 
            // In this template, we have chosen to set this to the AppliesToAddress.
            scope.ReplyToAddress = scope.AppliesToAddress;

            return scope;
        }

        protected override IClaimsIdentity GetOutputClaimsIdentity(IClaimsPrincipal principal,
                                                                   RequestSecurityToken request, Scope scope)
        {
            if (null == principal)
            {
                throw new ArgumentNullException("principal");
            }
            var outputIdentity = new ClaimsIdentity();


            var userName = principal.Identity.Name;
            using (var db = new StsContext())
            {
                var webUser = db.WebUsers.Single(w => w.Username == userName);
                foreach (var requestClaim in request.Claims)
                {
                    var value = GetValueForClaimRequest(requestClaim, webUser);
                    if (value != null)
                    {
                        outputIdentity.Claims.Add(new Claim(requestClaim.ClaimType, value));
                    }
                }
                if (!outputIdentity.Claims.Any(c => c.ClaimType == Security.ClaimTypes.Name))
                {
                    outputIdentity.Claims.Add(new Claim(Security.ClaimTypes.Name, webUser.Username));
                }
            }
            return outputIdentity;
        }

        string GetValueForClaimRequest(RequestClaim requestClaim, WebUser webUser)
        {
            switch (requestClaim.ClaimType)
            {
                case Security.ClaimTypes.Name:
                    return webUser.Username;
                case Security.ClaimTypes.EMail:
                    return webUser.EMail;
                case Security.ClaimTypes.Role:
                    return webUser.Role;
                default:
                    throw new FailedRequiredClaimsException(requestClaim.ClaimType);
            }
        }
    }
}