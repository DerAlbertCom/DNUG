using System;

namespace DotnetKoeln.STS.Settings
{
    public interface IHashingSettings
    {
        string Salt { get; }
    }
}