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
