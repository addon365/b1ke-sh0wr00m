using addon365.Chit.Context.Ef;
using addon365.Chit.DataService;
using addon365.Chit.DataService.Ef;
using addon365.Chit.ViewModel;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using Threenine.Data;

namespace addon365.Chit.App.Wpf.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {


            SimpleIoc.Default.Register<MainViewModel>();
            
            SimpleIoc.Default.Register<DatabaseContext>();
            SimpleIoc.Default.Register<IUnitOfWork<DatabaseContext>,UnitOfWork<DatabaseContext>>();

            SimpleIoc.Default.Register<ChitSubscriberViewModel>(()=>new ChitSubscriberViewModel(SubscriberDataService));
            SimpleIoc.Default.Register<IChitSubscriberDataService,ChitSubscriberDataService>();

            SimpleIoc.Default.Register<ChitSubscriberListViewModel>();
            SimpleIoc.Default.Register<IChitSubscriberListDataService, ChitSubscriberListDataService>();

            SimpleIoc.Default.Register<ChitSubscriberDueViewModel>();
            SimpleIoc.Default.Register<IChitSubscriberDueDataService, ChitSubscriberDueDataService>();


            SimpleIoc.Default.Register<ChitSubscriberDueListViewModel>();
            SimpleIoc.Default.Register<IChitSubscriberDueListDataService, ChitSubscriberDueListDataService>();

            SimpleIoc.Default.Register<ChitGroupViewModel>();
            SimpleIoc.Default.Register<IChitGroupDataService, ChitGroupDataService>();


        

            SimpleIoc.Default.Register<ChitGroupListViewModel>();
            SimpleIoc.Default.Register<IChitGroupListDataService, ChitGroupListDataService>();

            SimpleIoc.Default.Register<AgentViewModel>();
            SimpleIoc.Default.Register<IAgentDataService, AgentDataService>();


            SimpleIoc.Default.Register<AgentListViewModel>();
            SimpleIoc.Default.Register<IAgentListDataService, AgentListDataService>();

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
                return SimpleIoc.Default.GetInstanceWithoutCaching<ChitSubscriberViewModel>();
            }
        }
        public IChitSubscriberDataService SubscriberDataService
        {
            get
            {
                return SimpleIoc.Default.GetInstanceWithoutCaching<IChitSubscriberDataService>();
            }
        }
        public ChitSubscriberListViewModel ChitSubscriberList
        {
            get
            {
                return SimpleIoc.Default.GetInstanceWithoutCaching<ChitSubscriberListViewModel>();
            }
        }
        public ChitSubscriberDueViewModel SubscriberDue
        {
            get
            {
                return SimpleIoc.Default.GetInstanceWithoutCaching<ChitSubscriberDueViewModel>();
            }
        }
        public ChitSubscriberDueListViewModel SubscriberDueList
        {
            get
            {
                return SimpleIoc.Default.GetInstanceWithoutCaching<ChitSubscriberDueListViewModel>();
            }
        }
        public ChitGroupViewModel ChitGroup
        {
            get
            {
                return SimpleIoc.Default.GetInstanceWithoutCaching<ChitGroupViewModel>();
            }
        }
     
        public ChitGroupListViewModel ChitGroupList
        {
            get
            {
                return SimpleIoc.Default.GetInstanceWithoutCaching<ChitGroupListViewModel>();
            }
        }
        public AgentViewModel Agent
        {
            get
            {
                return SimpleIoc.Default.GetInstanceWithoutCaching<AgentViewModel>();
            }
        }
        public AgentListViewModel AgentList
        {
            get
            {
                return SimpleIoc.Default.GetInstanceWithoutCaching<AgentListViewModel>();
            }
        }

        private void NotifyUserMethod(NotificationMessage message)
        {
            MessageBox.Show(message.Notification);
        }
    }
}
