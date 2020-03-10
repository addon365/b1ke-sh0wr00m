

using addon365.Chit.DomainEntity;
using addon365.Chit.DataHelper;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace addon365.Chit.ViewModel
{
    public class ChitSubscriberDueViewModel : ViewModelBase
    {
        private IChitSubscriberDueDataService _chitSubscriberDueDataService;
        private ChitGroupModel _selectedChitGroup;
        private ChitSubscriberModel _selectedChitSubscriber;
        string _title,_accessId,_searchSubscriberAccessId;
        int _totalDue;
        decimal _paymentAmount;
        private ObservableCollection<ChitGroupModel> _chitGroupList;
        private ObservableCollection<ChitSubscriberModel> _chitSubscriberList;
        public ChitSubscriberDueViewModel(IChitSubscriberDueDataService chitSubscriberDueDataService)
        {
            this._chitSubscriberDueDataService = chitSubscriberDueDataService;
            if (IsInDesignMode)
            {
                Title = "Hello MVVM Light (Design Mode)";
            }
            else
            {
                Title = "Hello MVVM Light";
                LoadMasterData();
            }
            
            SaveSubscriberDueCommand = new RelayCommand(SaveSubscriberDue);
            FindSubscriberByIdCommand = new RelayCommand(FindSubscriberById);
        }
        public RelayCommand SaveSubscriberDueCommand { get; private set; }
        public RelayCommand FindSubscriberByIdCommand { get; private set; }
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
        public string AccessId
        {
            get
            {
                return _accessId;
            }
            set
            {
                _accessId = value;
                RaisePropertyChanged("AccessId");
            }
        }
        public string SearchSubscriberAccessId
        {
            get
            {
                return _searchSubscriberAccessId;
            }
            set
            {
                _searchSubscriberAccessId = value;
                RaisePropertyChanged("SearchSubscriberAccessId");
            }
        }
        public string FullName
        {
            get
            {
                string fullName = string.Empty;
                if (SelectedChitSubscriber != null)
                    fullName= SelectedChitSubscriber.Customer.FirstName + " " + SelectedChitSubscriber.Customer.LastName;

                return fullName;
            }
          
        }
   
        public int[] DueNumbers
        {
            get 
            {
                int[] dueNumbers = { 1 };
                return dueNumbers;

            }
        }
        public int SelectedDueNumber
        {
            get
            {
                return _totalDue;
            }
            set
            {
                _totalDue = value;

                if(SelectedChitSubscriber!=null)
                    PaymentAmount=SelectedChitSubscriber.ChitDueAmount* _totalDue;
                
                RaisePropertyChanged("SelectedDueNumber");
            }
        }
        public Decimal PaymentAmount
        {
            get
            {
                return _paymentAmount;
            }
            set
            {
                _paymentAmount = value;
                RaisePropertyChanged("PaymentAmount");
            }
        }

        public ObservableCollection<ChitSubscriberModel> ChitSubscriberList
        {
            get
            {
                return _chitSubscriberList;
            }
        }

        public ChitSubscriberModel SelectedChitSubscriber
        {
            get
            {
                return _selectedChitSubscriber;
            }
            set
            {
                _selectedChitSubscriber = value;
                RaisePropertyChanged("SelectedChitSubscriber");
                RaisePropertyChanged("FullName");
               
            }
        }
        public void LoadMasterData()
        {
            var masterData = _chitSubscriberDueDataService.GetMasterData();
            

            
            _chitSubscriberList = new ObservableCollection<ChitSubscriberModel>(masterData.ChitSubscriberList);
            this.RaisePropertyChanged(() => this.ChitSubscriberList);

            Int64 id = 1;
            if (masterData.MaxAccessId != null && masterData.MaxAccessId != "")
                id = Convert.ToInt64(masterData.MaxAccessId) + 1;

            AccessId = id.ToString();
        }

        public void SaveSubscriberDue()
        {
            try
            {
                _chitSubscriberDueDataService.Insert(GetCurrentSubcriberDue());
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
        public void FindSubscriberById()
        {
            try
            {
                if (SearchSubscriberAccessId == String.Empty)
                {
                    throw new Exception("Please enter Id");
                }

                    SelectedChitSubscriber = _chitSubscriberList.First(x => x.AccessId == SearchSubscriberAccessId);
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
        
        private ChitSubscriberDueModel GetCurrentSubcriberDue()
        {
            Validate();
            var model = new ChitSubscriberDueModel {ChitSubscriberKeyId=SelectedChitSubscriber.KeyId,Amount=this.PaymentAmount,AccessId=this.AccessId};
            return model;
        }

        private void Validate()
        {
            
        }
        public void Clear()
        {
            SearchSubscriberAccessId = string.Empty;
            SelectedChitSubscriber = null;
          
            LoadMasterData();

        }
       
        
    }
}
