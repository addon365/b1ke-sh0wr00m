using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace addon365.Chit.App.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
           
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTg5MzcwQDMxMzcyZTM0MmUzMENwN1Z6eTlQMGdOUHBsQkkzMk5yOGh5dlN5NW9DbzRFT1YwQzU2am9rdTQ9");
        }
    }
}
