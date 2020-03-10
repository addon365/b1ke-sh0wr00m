using addon365.Chit.DomainEntity;
using addon365.Chit.DataService;
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
    public class ChitGroupListViewModel : ViewModelBase
    {
        private IChitGroupListDataService _groupDataService;
        private ObservableCollection<ChitGroupModel> _chitGroupList;
        private ChitGroupModel _selectedChitGroup;
        public ChitGroupListViewModel(IChitGroupListDataService groupDataService)
        {
            try
            {
                this._groupDataService = groupDataService;
                if (IsInDesignMode)
                {
                    Title = "Hello MVVM Light (Design Mode)";
                }
                else
                {
                    Title = "Hello MVVM Light";
                    LoadChitGroup();
                }

                DeleteChitGroupCommand = new RelayCommand(DeleteChitGroup);
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
        public RelayCommand DeleteChitGroupCommand { get; private set; }
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
        public int PageSize { get; set; }
        private void LoadChitGroup()
        {
            var data = _groupDataService.Get(1, 5000);
            _chitGroupList = new ObservableCollection<ChitGroupModel>(data);
            this.RaisePropertyChanged(() => this.ChitGroupList);
    
        }
        
        void DeleteChitGroup()
        {
            try
            {
                _groupDataService.Delete(SelectedChitGroup.KeyId);
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Deleted"));
                LoadChitGroup();
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
