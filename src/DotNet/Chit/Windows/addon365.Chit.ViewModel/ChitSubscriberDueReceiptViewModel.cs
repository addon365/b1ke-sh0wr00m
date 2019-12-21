

using addon365.Chit.DomainEntity;
using addon365.Chit.IDataService;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace addon365.Chit.ViewModel
{
    public class ChitSubscriberDueReceiptViewModel : ViewModelBase
    {
        private IChitSubscriberDataService _chitSubscriberDataService;
        private ChitGroupModel _selectedChitGroup;
        string _title,_firstName,_lastName,_mobileNumber,_place,_address;
        private ObservableCollection<ChitGroupModel> _chitGroupList;
        public ChitSubscriberDueReceiptViewModel(IChitSubscriberDataService chitSubscriberDataService)
        {
            this._chitSubscriberDataService = chitSubscriberDataService;
            if (IsInDesignMode)
            {
                Title = "Hello MVVM Light (Design Mode)";
            }
            else
            {
                Title = "Hello MVVM Light";
                LoadMasterData();
            }
            
            SaveSubscriberCommand = new RelayCommand(SaveSubscriber);
        }
        public ICommand SaveSubscriberCommand { get; private set; }
        
        public string Title 
        {
            get 
            {
                return _title;
            }
            set 
            {
                _title = value;
                RaisePropertyChanged("Title");
            } 
        }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                RaisePropertyChanged("FirstName");
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                RaisePropertyChanged("LastName");
            }
        }
        public string MobileNumber
        {
            get
            {
                return _mobileNumber;
            }
            set
            {
                _mobileNumber = value;
                RaisePropertyChanged("MobileNumber");
            }
        }
        public string Place
        {
            get
            {
                return _place;
            }
            set
            {
                _place = value;
                RaisePropertyChanged("Place");
            }
        }
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                RaisePropertyChanged("Address");
            }
        }
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
        public void LoadMasterData()
        {
            _chitGroupList = new ObservableCollection<ChitGroupModel>(_chitSubscriberDataService.GetMasterData().ChitGroupList);
            this.RaisePropertyChanged(() => this.ChitGroupList);
        }

        public void SaveSubscriber()
        {
            try
            {
                //_subscriberDataService.GetAll();
                _chitSubscriberDataService.Insert(GetCurrentSubcriber());
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Subscriber Saved."));
                Clear();
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
        
        private ChitSubscriberModel GetCurrentSubcriber()
        {
            Validate();
            return new ChitSubscriberModel { FirstName = this.FirstName, LastName = this.LastName, MobileNo = this.MobileNumber, Place = this.Place, Address = this.Address,ChitGroupKeyId=this.SelectedChitGroup.KeyId};
        }

        private void Validate()
        {
            if (SelectedChitGroup == null)
                throw new Exception("Chit Scheme not selected");
        }
        public void Clear()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            MobileNumber = string.Empty;
            Place = string.Empty;
            Address = string.Empty;
            SelectedChitGroup = null;

        }
        public void LoadSubscriber()
        {
            
        }
        
    }
}
