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
    public class ChitGroupListViewModel: ViewModelBase
    {
        private IChitGroupListDataService _groupDataService;
        private ObservableCollection<ChitGroupModel> _chitGroupList;
        private ChitGroupModel _selectedChitGroup;
        public ChitGroupListViewModel(IChitGroupListDataService groupDataService)
        {
            this._groupDataService = groupDataService;
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

        public ObservableCollection<ChitGroupModel> ChitGroupList
        {
            get
            {
                return _chitGroupList;
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
            _chitGroupList = new ObservableCollection<ChitGroupModel>(_groupDataService.GetAll());
            this.RaisePropertyChanged(() => this.ChitGroupList);
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Chit Group Loaded."));
        }
        void DeleteChitGroup()
        {

        }

    }
}
