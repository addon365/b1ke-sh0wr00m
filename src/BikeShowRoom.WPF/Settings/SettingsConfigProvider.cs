using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeShowRoom.WPF.Settings
{
    class SettingsConfigProvider : IConfigProvider
    {
        public string Host { get; set; }
        public int Port { get; set; }

        public void Load()
        {
            AppSettings settings = AppSettingsLocator.Instance;

            this.Host = settings.Host;
            this.Port = settings.Port;
        }

        public void Save()
        {
            AppSettings settings = AppSettingsLocator.Instance;

            settings.Host = this.Host;
            settings.Port = this.Port;

            settings.Save();
        }
    }
}
