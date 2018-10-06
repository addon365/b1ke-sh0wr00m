using Api.Database;
using Swc.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Threenine.Data;
using Unity;
using ViewModel;

namespace BikeShowRoom.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {      
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzE5NDFAMzEzNjJlMzMyZTMwZk1vMlVQNDczbzZXc2Q3cTJwZWJYTVZ0QnVBZlRNZVdHRWQ5Sm1qazM1QT0=;MzE5NDJAMzEzNjJlMzMyZTMwV1JncnkvZ0NVeS9vRmxDVDZUNEpCY3k4b1IzZndMc1RSYjlFQU5IZHNGWT0=;MzE5NDNAMzEzNjJlMzMyZTMwSHRxUmlOK1RoRExJRmVRblpSSFN1RC9rbjF6amFjYUwwRnFTcEd5bktXOD0=;MzE5NDRAMzEzNjJlMzMyZTMwQ3ZJWkpZN0E5Nk5NVFZDUTNmTzRjd2NCcmhPZFNuNmhYaUVqcFdQNDdOZz0=;MzE5NDVAMzEzNjJlMzMyZTMwZVVrVTZ4T2pNSFlGejljRWtjRnJWMUI4NStYdFBjN3BvLzYrNGhYdm12QT0=;MzE5NDZAMzEzNjJlMzMyZTMwVTZQVFNkVHlKOGlZYVBRY0VOVVJSWWpjVkJ6TTNCTjJWRTBYMlhoV0xZTT0=;MzE5NDdAMzEzNjJlMzMyZTMwUWFZY01vbDlpWDFlRjE2VzJmQjEyNGxhYVNOOU9PakpscDE4QUJTZlNzRT0=;MzE5NDhAMzEzNjJlMzMyZTMwT1JKTXh2a1VxYmpydFNnckN4Q0t3RTU2MnluVkpKOGJZSXFydU5Uc3ExUT0=;MzE5NDlAMzEzNjJlMzMyZTMwRjhIMWczY252MDFhWVlTeS82QmhOTVVvcGQvMk03L1ZDRGVIeTFJSlptdz0=");
        }

        protected override void OnStartup(StartupEventArgs e)
        {
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
