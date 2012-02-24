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
        readonly IApplicationSettings settings;

        public IssuerSettings(IActionUrlBuilder urlBuilder, IApplicationSettings settings)
        {
            this.urlBuilder = urlBuilder;
            this.settings = settings;
        }

        public string IssuerUri
        {
            get { return urlBuilder.GetActionUrl("Index", "Home"); }
        }

        public string ServiceName
        {
            get { return "http://dotnet-koelnbonn.de/sts"; }
        }

        public X509Certificate2 ServiceCert
        {
            get
            {
                var certName = settings.Get<string>("Issuer.SigningCertificateName");
                return X509CertificateUtil.GetCertificate(
                    settings.Get("Issuer.StoreName",()=>StoreName.TrustedPeople),
                    settings.Get("Issuer.StoreLocation", () => StoreLocation.LocalMachine),
                    certName);
                //return X509CertificateUtil.GetCertificate(
                //    StoreName.My,
                //    StoreLocation.LocalMachine,
                //    certName);
            }
        }

        public bool Sign
        {
            get { return settings.Get("Issuer.Sign", () => false); }
        }
    }
}