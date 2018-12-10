using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeShowRoom.WPF.Settings
{
    sealed class AppSettings : ApplicationSettingsBase
    {
        [UserScopedSettingAttribute()]
        public string Host
        {
            get { return (string)(this["Host"]); }
            set { this["Host"] = value; }
        }

        [UserScopedSettingAttribute()]
        [DefaultSettingValue("8080")]
        public int Port
        {
            get { return (int)(this["Port"]); }
            set { this["Port"] = value; }
        }
    }
}
