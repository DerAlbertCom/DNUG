using System.Collections.Generic;

namespace DotnetKoeln.STS.Services
{
    public interface IEndpointSettings
    {
        ICollection<string> ActiveEndpoints { get; }
        ICollection<string> PassiveEndpoints { get; }
    }
}