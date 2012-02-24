using Microsoft.IdentityModel.Protocols.WSFederation.Metadata;

namespace DotnetKoeln.STS.Services
{
    public interface IMetadataContactSettings
    {
        ContactPerson Contact { get; }
        Organization Organization { get; }
    }
}