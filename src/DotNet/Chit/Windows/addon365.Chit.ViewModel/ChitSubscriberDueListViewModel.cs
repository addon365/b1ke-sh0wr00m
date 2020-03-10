using addon365.Chit.DomainEntity;
using addon365.Chit.DataService;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace addon365.Chit.ViewModel
{
    public class ChitSubscriberDueListViewModel : ViewModelBase
    {
        private IChitSubscriberDueListDataService _chitSubscriberDueListDataService;
        private ObservableCollection<ChitSubscriberDueListModel> _chitSubscriberDueList;
        private ChitSubscriberDueListModel _selectedSubscriberDue;
        public ChitSubscriberDueListViewModel(IChitSubscriberDueListDataService chitSubscriberDueListDataService)
        {
            this._chitSubscriberDueListDataService = chitSubscriberDueListDataService;
            if (IsInDesignMode)
            {
                Title = "Hello MVVM Light (Design Mode)";
            }
            else
            {
                Title = "Hello MVVM Light";
                LoadMethod();
            }

            DeleteSubscriberDueCommand = new RelayCommand(DeleteSubscriberDue);
        }
        public RelayCommand DeleteSubscriberDueCommand { get; private set; }
        public string Title { get; set; }

        public ObservableCollection<ChitSubscriberDueListModel> ChitSubscriberDueList
        {
            get
            {
                return _chitSubscriberDueList;
            }
        }

        public ChitSubscriberDueListModel SelectedSubscriberDue
        {
            get
            {
                return _selectedSubscriberDue;
            }
            set
            {
                _selectedSubscriberDue = value;
                RaisePropertyChanged("SelectedSubscriberDue");
            }
        }
        private void LoadMethod()
        {
            _chitSubscriberDueList = new ObservableCollection<ChitSubscriberDueListModel>(_chitSubscriberDueListDataService.GetAll().OrderBy(x => Convert.ToInt32(x.AccessId)));
            this.RaisePropertyChanged(() => this.ChitSubscriberDueList);
            //Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Chit Group Loaded."));
        }
        void DeleteSubscriberDue()
        {

        }

    }
}
