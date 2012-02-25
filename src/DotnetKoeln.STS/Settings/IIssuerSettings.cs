using System;
using System.Security.Cryptography.X509Certificates;
using Aperea.Settings;
using DotnetKoeln.STS.Services;
using DotnetKoeln.STS.TokenService;

namespace DotnetKoeln.STS.Settings
{
    public interface IIssuerSettings
    {
        string IssuerUri { get; }
        string ServiceName { get; }
        X509Certificate2 ServiceCert { get; }
        bool Sign { get; }
    }

    public class IssuerSettings : IIssuerSettings
    {
        readonly IActionUrlBuilder urlBuilder;
        readonly ICertificateSettings settings;
        readonly IApplicationSettings applicationSettings;

        public IssuerSettings(IActionUrlBuilder urlBuilder, ICertificateSettings settings,
                              IApplicationSettings applicationSettings)
        {
            this.urlBuilder = urlBuilder;
            this.settings = settings;
            this.applicationSettings = applicationSettings;
        }

        public string IssuerUri
        {
            get { return urlBuilder.GetActionUrl("Index", "Home"); }
        }

        public string ServiceName
        {
            get { return "dotnet-koelnbonn.de"; }
        }

        public X509Certificate2 ServiceCert
        {
            get
            {
                var certName = settings.SigningCertificateName;
                return X509CertificateUtil.GetCertificate(
                    settings.StoreName,
                    settings.StoreLocation,
                    certName);
            }
        }

        public bool Sign
        {
            get { return applicationSettings.Get("Issuer.Sign", () => false); }
        }
    }
}