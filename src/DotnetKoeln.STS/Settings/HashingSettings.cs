using System;
using Aperea.Settings;

namespace DotnetKoeln.STS.Settings
{
    public class HashingSettings : IHashingSettings
    {
        readonly IApplicationSettings settings;

        public HashingSettings(IApplicationSettings settings)
        {
            this.settings = settings;
        }

        public string Salt
        {
            get { return settings.Get("hash.Salt", () => "gesalzen"); }
        }
    }
}