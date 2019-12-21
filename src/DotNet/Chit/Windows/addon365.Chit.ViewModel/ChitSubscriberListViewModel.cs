using addon365.Chit.DomainEntity;
using addon365.Chit.IDataService;
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
        private ObservableCollection<ChitSubscriberModel> _chitSubscriberList;
        private ChitGroupModel _selectedChitGroup;
        public ChitSubscriberListViewModel(IChitSubscriberListDataService chitSubscriberListDataService)
        {
            this._chitSubscriberListDataService = chitSubscriberListDataService;
            if (IsInDesignMode)
            {
                Title = "Hello MVVM Light (Design Mode)";
            }
            else
            {
                Title = "Hello MVVM Light";
                LoadMethod();
            }
            
            DeleteChitGroupCommand = new RelayCommand(DeleteChitGroup);
        }
        public ICommand DeleteChitGroupCommand { get; private set; }
        public string Title { get; set; }

        public ObservableCollection<ChitSubscriberModel> ChitSubscriberList
        {
            get
            {
                return _chitSubscriberList;
            }
        }

        public ChitGroupModel SelectedChitGroup
        {
            get
            {
                return _selectedChitGroup;
            }
            set
            {
                _selectedChitGroup = value;
                RaisePropertyChanged("SelectedChitGroup");
            }
        }
        private void LoadMethod()
        {
            _chitSubscriberList = new ObservableCollection<ChitSubscriberModel>(_chitSubscriberListDataService.GetAll());
            this.RaisePropertyChanged(() => this.ChitSubscriberList);
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Chit Group Loaded."));
        }
        void DeleteChitGroup()
        {

        }

    }
}
