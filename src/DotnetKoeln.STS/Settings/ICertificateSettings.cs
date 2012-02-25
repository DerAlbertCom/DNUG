using System.Security.Cryptography.X509Certificates;
using Aperea.Settings;

namespace DotnetKoeln.STS.Settings
{
    public interface ICertificateSettings
    {
        string SigningCertificateName { get; }
        string EncryptingCertificateName { get; }
        StoreName StoreName { get; }
        StoreLocation StoreLocation { get; }
    }

    public class CertificateSettings : ICertificateSettings
    {
        IApplicationSettings settings;

        public CertificateSettings(IApplicationSettings settings)
        {
            this.settings = settings;
        }

        public string SigningCertificateName
        {
            get { return settings.Get<string>("Issuer.SigningCertificateName"); }
        }

        public string EncryptingCertificateName
        {
            get { return settings.Get<string>("Issuer.EncryptingCertificateName"); }
        }

        public StoreName StoreName
        {
            get { return settings.Get("Issuer.StoreName", () => StoreName.My); }
        }

        public StoreLocation StoreLocation
        {
            get { return settings.Get("Issuer.StoreLocation", () => StoreLocation.CurrentUser); }
        }
    }
}