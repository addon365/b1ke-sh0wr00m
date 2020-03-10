using addon365.Chit.DomainEntity;
using addon365.Chit.DataHelper;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace addon365.Chit.ViewModel
{
    public class ChitSubscriberListViewModel : ViewModelBase
    {
        private IChitSubscriberListDataService _chitSubscriberListDataService;
        private ObservableCollection<ChitSubscriberListModel> _chitSubscriberList;
        private ChitSubscriberListModel _selectedSubscriber;
        public ChitSubscriberListViewModel(IChitSubscriberListDataService chitSubscriberListDataService)
        {
            try
            {
                this._chitSubscriberListDataService = chitSubscriberListDataService;
            if (IsInDesignMode)
            {
                Title = "Subscriber List (Design Mode)";
            }
            else
            {
                Title = "Subscriber List";
                LoadMethod();
            }

            DeleteSubscriberCommand = new RelayCommand(DeleteSubscriber);
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ex.Message));
            }
        }
        public RelayCommand DeleteSubscriberCommand { get; private set; }
        public string Title { get; set; }

        public ObservableCollection<ChitSubscriberListModel> ChitSubscriberList
        {
            get
            {
                return _chitSubscriberList;
            }
        }

        public ChitSubscriberListModel SelectedSubscriber
        {
            get
            {
                return _selectedSubscriber;
            }
            set
            {
                _selectedSubscriber = value;
                RaisePropertyChanged("SelectedSubscriber");
            }
        }
        private void LoadMethod()
        {
            _chitSubscriberList = new ObservableCollection<ChitSubscriberListModel>(_chitSubscriberListDataService.GetAll());
            this.RaisePropertyChanged(() => this.ChitSubscriberList);
        }
        public void DeleteSubscriber()
        {
            try
            { 
            if (SelectedSubscriber == null)
            {
            
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Subscriber not Selected"));
                return;
            }
            _chitSubscriberListDataService.Delete(SelectedSubscriber.KeyId);
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Deleted"));
                LoadMethod();
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ex.Message));
            }
        }

    }
}
