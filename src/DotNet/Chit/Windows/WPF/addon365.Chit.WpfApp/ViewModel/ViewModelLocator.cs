using addon365.Chit.DataService;
using addon365.Chit.EfContext;
using addon365.Chit.IDataService;
using addon365.Chit.ViewModel;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Threenine.Data;

namespace addon365.Chit.WpfApp.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {


            SimpleIoc.Default.Register<MainViewModel>();
            
            SimpleIoc.Default.Register<DatabaseContext>();
            SimpleIoc.Default.Register<IUnitOfWork<DatabaseContext>,UnitOfWork<DatabaseContext>>();

            SimpleIoc.Default.Register<ChitSubscriberViewModel>();
            SimpleIoc.Default.Register<IChitSubscriberDataService,ChitSubscriberDataService>();

            SimpleIoc.Default.Register<ChitSubscriberListViewModel>();
            SimpleIoc.Default.Register<IChitSubscriberListDataService, ChitSubscriberListDataService>();

            SimpleIoc.Default.Register<ChitGroupViewModel>();
            SimpleIoc.Default.Register<IChitGroupDataService, ChitGroupDataService>();

            SimpleIoc.Default.Register<ChitGroupListViewModel>();
            SimpleIoc.Default.Register<IChitGroupListDataService, ChitGroupListDataService>();

            Messenger.Default.Register<NotificationMessage>(this, NotifyUserMethod);
       
                
        }
       
        public MainViewModel Main
        {
            get
            {
                return SimpleIoc.Default.GetInstance<MainViewModel>();
            }
        }
        public ChitSubscriberViewModel Subscriber
        {
            get
            {
                return SimpleIoc.Default.GetInstance<ChitSubscriberViewModel>();
            }
        }
        public ChitGroupViewModel ChitGroup
        {
            get
            {
                return SimpleIoc.Default.GetInstance<ChitGroupViewModel>();
            }
        }
        public ChitGroupListViewModel ChitGroupList
        {
            get
            {
                return SimpleIoc.Default.GetInstance<ChitGroupListViewModel>();
            }
        }
        public ChitSubscriberListViewModel ChitSubscriberList
        {
            get
            {
                return SimpleIoc.Default.GetInstance<ChitSubscriberListViewModel>();
            }
        }
        private void NotifyUserMethod(NotificationMessage message)
        {
            MessageBox.Show(message.Notification);
        }
    }
}
