using BikeShowRoom.WPF.Settings;
using System;
using System.Runtime.ExceptionServices;
using System.Windows;

namespace BikeShowRoom.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {      
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTQ0MjNAMzEzNjJlMzQyZTMwU2xWaXVWWCtIZnZ3QWoyekdWazh6MWtqUU9GY3I3UGhtdGFrZnNpUXNYQT0=;NTQ0MjRAMzEzNjJlMzQyZTMwaC9aMk1PbUlpR04zK0JraVkrQ0tmdDVKUUZZVHF0ck1GNExtaXczMEwzdz0=;NTQ0MjVAMzEzNjJlMzQyZTMwSzJVY00zek9WYWtQQlFwaXg4dStPVkI4OGxycWhsRXY1K3g1MDY4bG9Taz0=;NTQ0MjZAMzEzNjJlMzQyZTMwb0FyUGZhaVpzb3o2Q3ljclZZZnBOam9lYVlIa3p4RkJBOUNNaERPS2ljWT0=;NTQ0MjdAMzEzNjJlMzQyZTMwTytudmZpZ2xHS0FKZVJTeDkxbnNDQlVxNUIyWEdGMkdNMThWRjIxTTU5ND0=;NTQ0MjhAMzEzNjJlMzQyZTMwSVNCQjhra0MxV3pFRU9TMm05NUNjWXJSMkszRDYxeXBuY3dldENnKzM2TT0=;NTQ0MjlAMzEzNjJlMzQyZTMwa3J6Ty85T0RFMVRTOEJsMlArMkVPalNra21iZU1nR2pqVldmR0NDSzluZz0=;NTQ0MzBAMzEzNjJlMzQyZTMwbTRyQWN2QUJ5aDJwSmhwWkxYT29EL0srWDU1b0xqai80bVM4c2I4K3psbz0=;NTQ0MzFAMzEzNjJlMzQyZTMwSUJ4MlRBWEkvMkZKWHk3aXNFUlUyRFE2UnBlUDk0QWpwS3hOS2d1TCtsbz0=");
            AppDomain.CurrentDomain.FirstChanceException += new EventHandler<System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs>(CurrentDomain_FirstChanceException);


        }

        private void CurrentDomain_FirstChanceException(object sender, FirstChanceExceptionEventArgs e)
        {
            //Dispatcher.BeginInvoke(new Action(() => MessageBox.Show("Error Occurred \n\r" + e.Exception.Message + "\n\r" + e.Exception.StackTrace, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error)));
        }
        protected override void OnStartup(StartupEventArgs e)
        {

           // ContainerNSR.APP_SETTINGS = "somevalue"

                                           //IUnityContainer container = new UnityContainer();
                                           //container.RegisterType<IRepositoryFactory, UnitOfWork<ApiContext>>();

            //container.RegisterType<IUnitOfWork, UnitOfWork<ApiContext>>();

            //container.RegisterType<IUnitOfWork<ApiContext>, UnitOfWork<ApiContext>>();
            //container.RegisterType<ISampleService, SampleService>();


            //MainWindow mainWindow = container.Resolve<MainWindow>();
            //mainWindow.Show();
        }

    }
}
