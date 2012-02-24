using System;
using Aperea.Settings;

namespace UserGroup.Settings
{
    public class MailSettings : IMailSettings
    {
        readonly IApplicationSettings settings;

        public MailSettings(IApplicationSettings settings)
        {
            this.settings = settings;
        }

        public string MailFrom
        {
            get { return settings.Get<string>("Mail.From"); }
        }
    }
}