using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addon365.UI.WPF.Settings
{
    
        class AppSettingsLocator
        {
            private AppSettingsLocator()
            {
            }

            static AppSettings instance;

            public static AppSettings Instance
            {
                get
                {
                    if (instance == null)
                        instance = new AppSettings();

                    return instance;
                }
            }
        }
    
}
