using System;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using Aperea.Identity;
using Aperea.Identity.Settings;
using DotnetKoeln.STS.Settings;
using Microsoft.IdentityModel.Configuration;
using Microsoft.IdentityModel.SecurityTokenService;
using Microsoft.Practices.ServiceLocation;

namespace DotnetKoeln.STS.TokenService
{
    /// <summary>
    /// A custom SecurityTokenServiceConfiguration implementation.
    /// </summary>
    public class DotnetKoelnSecurityTokenServiceConfiguration : SecurityTokenServiceConfiguration
    {
        static readonly object syncRoot = new object();
        const string CustomSecurityTokenServiceConfigurationKey = "DotnetKoelnSecurityTokenServiceConfiguration";

        /// <summary>
        /// Provides a model for creating a single Configuration object for the application. The first call creates a new CustomSecruityTokenServiceConfiguration and 
        /// places it into the current HttpApplicationState using the key "CustomSecurityTokenServiceConfigurationKey". Subsequent calls will return the same
        /// Configuration object.  This maintains any state that is set between calls and improves performance.
        /// </summary>
        public static DotnetKoelnSecurityTokenServiceConfiguration Current
        {
            get
            {
                HttpApplicationState httpAppState = HttpContext.Current.Application;

                var customConfiguration =
                    httpAppState.Get(CustomSecurityTokenServiceConfigurationKey) as
                    DotnetKoelnSecurityTokenServiceConfiguration;

                if (customConfiguration == null)
                {
                    lock (syncRoot)
                    {
                        customConfiguration = httpAppState.Get(CustomSecurityTokenServiceConfigurationKey) as
                            DotnetKoelnSecurityTokenServiceConfiguration;

                        if (customConfiguration == null)
                        {
                            customConfiguration = new DotnetKoelnSecurityTokenServiceConfiguration();
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
        public DotnetKoelnSecurityTokenServiceConfiguration()
            : base(GetIssuerName(), new X509SigningCredentials(GetCertificate()))
        {
            SecurityTokenService = typeof (DotnetKoelnSecurityTokenService);
        }

        static string GetIssuerName()
        {
            var configuration = ServiceLocator.Current.GetInstance<IIdentityProviderConfiguration>();
            return configuration.ServiceName;
        }

        static X509Certificate2 GetCertificate()
        {
            var settings = ServiceLocator.Current.GetInstance<ISigningSettings>();
            return settings.Certificate;
        }
    }
}