using System.Security.Cryptography.X509Certificates;

namespace DotnetKoeln.STS.Services
{
    public interface IIssuerSettings
    {
        string IssuerUri { get; }
        string ServiceName { get; }
        X509Certificate2 ServiceCert { get; }
        bool Sign { get; }
    }
}