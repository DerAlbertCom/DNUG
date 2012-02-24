using System;
using Aperea.Settings;

namespace UserGroup.Settings
{
    public class CultureSettings : ICultureSettings
    {
        readonly IApplicationSettings settings;

        public CultureSettings(IApplicationSettings settings)
        {
            this.settings = settings;
        }

        public string[] PossibleCultures
        {
            get { return settings.Get<string>("Culture.PossibleCultures").Split(new[] {';', ','}); }
        }

        public string DefaultCulture
        {
            get { return settings.Get("Culture.Default", () => "de"); }
        }
    }
}