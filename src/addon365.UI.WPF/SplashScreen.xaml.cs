using addon365.Database.Entity.User;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using addon365.UI.ViewModel;

namespace addon365.UI.WPF
{
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {
        LoginViewModel loginViewModel;
        SplashViewModel _splashViewModel;
        
        public SplashScreen()
        {
            InitializeComponent();
            _splashViewModel = new SplashViewModel(CallOnRetry);
            DataContext = _splashViewModel;
            ServerStatusAsync();
            
        }
        public SplashViewModel SplashModel
        {
            get
            {
                return _splashViewModel;
            }
        }
        private void UpdateSessionStorageInfo()
        {
            Task.Run(() =>
            {
                bool showLogin = true;
#if DEBUG
                if (SplashModel.HasSessionInfo())
                {
                    SetText("Restoring session");
                    showLogin = !SplashModel.UpdateSessionInfo();
                }
#endif
                ShowWindow(showLogin);
                
            });
        }
        void SetText(string text)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                lblProgress.Content = text;
            }), DispatcherPriority.Background);
        }
        void ShowWindow(bool showLogin)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                if (showLogin)
                {
                    Login login = new Login();
                    login.Show();

                }
                else
                {
                    ContactWindow win = new ContactWindow();
                    win.Show();
                }
                this.Close();
            }), DispatcherPriority.Background);
        }
        public void CallOnRetry()
        {
            SplashModel.ShowRetry = false;
            ServerStatusAsync();
            
        }
        private async Task ServerStatusAsync()
        {

            SetText("Checking Internet...");
#if !DEBUG
            if (!InternetAvailability.IsInternetAvailable())
            {
                SetText("Internet Not Availlable");
                SplashModel.ShowRetry = true;
                return;
            }
#endif
            SetText("Internet Availlable");
            try
            {
                SetText("Checking Server Status...");
                //HttpResponseMessage message = await SplashModel.GetServiceStatus();
                //if (message.IsSuccessStatusCode)
                //{
                //    SetText("REST API up & good.");
                    UpdateSessionStorageInfo();
                //}
                //else
                //    SetText("Server  " + message.ReasonPhrase);

            }
            catch (Exception exception)
            {
                SetText(exception.Message);
            }

        }
    } 
}
