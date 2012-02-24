using System;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Configuration;
using Microsoft.IdentityModel.Configuration;
using Microsoft.IdentityModel.SecurityTokenService;

namespace DotnetKoeln.STS.TokenService
{
    /// <summary>
    /// A custom SecurityTokenServiceConfiguration implementation.
    /// </summary>
    public class StotaxSecurityTokenServiceConfiguration : SecurityTokenServiceConfiguration
    {

        static readonly object syncRoot = new object();
        const string CustomSecurityTokenServiceConfigurationKey = "CustomSecurityTokenServiceConfigurationKey";

        /// <summary>
        /// Provides a model for creating a single Configuration object for the application. The first call creates a new CustomSecruityTokenServiceConfiguration and 
        /// places it into the current HttpApplicationState using the key "CustomSecurityTokenServiceConfigurationKey". Subsequent calls will return the same
        /// Configuration object.  This maintains any state that is set between calls and improves performance.
        /// </summary>
        public static StotaxSecurityTokenServiceConfiguration Current
        {
            get
            {
                HttpApplicationState httpAppState = HttpContext.Current.Application;

                var customConfiguration =
                    httpAppState.Get(CustomSecurityTokenServiceConfigurationKey) as
                    StotaxSecurityTokenServiceConfiguration;

                if (customConfiguration == null)
                {
                    lock (syncRoot)
                    {
                        customConfiguration =
                            httpAppState.Get(CustomSecurityTokenServiceConfigurationKey) as
                            StotaxSecurityTokenServiceConfiguration;

                        if (customConfiguration == null)
                        {
                            customConfiguration = new StotaxSecurityTokenServiceConfiguration();
                            httpAppState.Add(CustomSecurityTokenServiceConfigurationKey, customConfiguration);
                        }
                    }
                }

                return customConfiguration;
            }
        }

        /// <summary>
        /// StotaxSecurityTokenServiceConfiguration constructor.
        /// </summary>
        public StotaxSecurityTokenServiceConfiguration()
            : base(WebConfigurationManager.AppSettings[Common.IssuerName],
                   new X509SigningCredentials(X509CertificateUtil.GetCertificate(StoreName.My, GetStoreLocation(),
                                                                             WebConfigurationManager.AppSettings[
                                                                                 Common.SigningCertificateName])))
        {
            SecurityTokenService = typeof (StotaxSecurityTokenService);
        }

        static StoreLocation GetStoreLocation()
        {
            return Environment.UserInteractive ? StoreLocation.CurrentUser : StoreLocation.LocalMachine;
        }
    }
}