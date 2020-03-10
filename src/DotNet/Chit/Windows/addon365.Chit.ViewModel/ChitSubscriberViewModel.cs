

using addon365.Chit.DomainEntity;
using addon365.Chit.DataService;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace addon365.Chit.ViewModel
{
    public class ChitSubscriberViewModel : ViewModelBase
    {
        private IChitSubscriberDataService _chitSubscriberDataService;
        Guid _keyId;
        string _title,_accessId,_firstName,_lastName,_mobileNumber,_place,_address;
        private ObservableCollection<ChitGroupModel> _chitGroupList;
        private ChitGroupModel _selectedChitGroup;
        private CustomerModel _selectedCustomer;
        private ObservableCollection<AgentModel> _agentList;
        private AgentModel _selectedAgent;
        private string _searchAgentAccessId,_searchChitGroupAccessId,_searchCustomerAccessId;
        private bool _editMode = false;
        public ChitSubscriberViewModel(IChitSubscriberDataService chitSubscriberDataService)
        {
            try
            {
                this._chitSubscriberDataService = chitSubscriberDataService;
                if (IsInDesignMode)
                {
                    Title = "Subscriber Window (Design Mode)";
                }
                else
                {
                    Title = "Subscriber Window";
                    LoadMasterData();
                }

                SaveSubscriberCommand = new RelayCommand(SaveSubscriber);
                FindAgentByIdCommand = new RelayCommand(FindAgentById);
                FindChitGroupByIdCommand = new RelayCommand(FindChitGroupById);
            }
            catch(Exception ex)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ex.Message));
            }
        }
        
        public RelayCommand SaveSubscriberCommand { get; private set; }
        public RelayCommand FindAgentByIdCommand { get; private set; }
        public RelayCommand FindChitGroupByIdCommand { get; private set; }

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
        public Guid KeyId
        {
            get
            {
                return _keyId;
            }
            set
            {
                _keyId = value;
                RaisePropertyChanged("KeyId");
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
        public string SearchCustomerAccessId
        {
            get
            {
                return _searchCustomerAccessId;
            }
            set
            {
                _searchCustomerAccessId = value;
                RaisePropertyChanged("SearchCustomerAccessId");
            }
        }
      
        public CustomerModel SelectedCustomer
        {
            get
            {
                return _selectedCustomer;
            }
            set
            {
                _selectedCustomer = value;
                RaisePropertyChanged("SelectedCustomer");
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
        public string SearchChitGroupAccessId
        {
            get
            {
                return _searchChitGroupAccessId;
            }
            set
            {
                _searchChitGroupAccessId = value;
                RaisePropertyChanged("SearchChitGroupAccessId");
            }
        }
     

        public AgentModel SelectedAgent
        {
            get
            {
                return _selectedAgent;
            }
            set
            {
                _selectedAgent = value;
                RaisePropertyChanged("SelectedAgent");
            }
        }
        public string SearchAgentAccessId
        {
            get
            {
                return _searchAgentAccessId;
            }
            set
            {
                _searchAgentAccessId = value;
                RaisePropertyChanged("SearchAgentAccessId");
            }
        }
        public void LoadMasterData()
        {
            var masterData = _chitSubscriberDataService.GetMasterData();
            Int64 id = 1;
            if (masterData.MaxAccessId != null && masterData.MaxAccessId != "")
                id = Convert.ToInt64(masterData.MaxAccessId)+1;

            AccessId = id.ToString();

            Int64 customerId = 1;
            if (masterData.MaxCustomerAccessId != null && masterData.MaxCustomerAccessId != "")
                customerId = Convert.ToInt64(masterData.MaxCustomerAccessId) + 1;

            SelectedCustomer = new CustomerModel { AccessId=customerId.ToString()};

 
        }

        public void SaveSubscriber()
        {
            try
            {
                ChitSubscriberModel chitSubscriberModel = GetSubcriber();
                //_subscriberDataService.GetAll();
                if (_editMode == false)
                {
                    _chitSubscriberDataService.Insert(chitSubscriberModel);
                    Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Subscriber Saved."));
                }
                else
                {
                    chitSubscriberModel.KeyId = this.KeyId;
                    _chitSubscriberDataService.Update(chitSubscriberModel);
                    Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Subscriber Saved."));
                }
                Clear();
                LoadMasterData();
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
        
        private ChitSubscriberModel GetSubcriber()
        {
            Validate();
            return new ChitSubscriberModel {AccessId=this.AccessId,Customer=SelectedCustomer,ChitGroup=SelectedChitGroup,Agent=this.SelectedAgent};
        }
        private void SetSubcriber(ChitSubscriberModel chitSubscriberModel)
        {
            KeyId = chitSubscriberModel.KeyId;
            AccessId = chitSubscriberModel.AccessId;

            SearchCustomerAccessId = chitSubscriberModel.Customer.AccessId;
            SelectedCustomer = chitSubscriberModel.Customer;

            SearchChitGroupAccessId = chitSubscriberModel.ChitGroup.AccessId;
            SelectedChitGroup = chitSubscriberModel.ChitGroup;
           
            SearchAgentAccessId = chitSubscriberModel.Agent.AccessId;
            SelectedAgent = chitSubscriberModel.Agent;
        }
        private void Validate()
        {
            if (SelectedChitGroup == null)
                throw new Exception("Chit Scheme not selected");
        }
        public void Clear()
        {
            SelectedCustomer = null;
            SelectedChitGroup = null;
            SelectedAgent = null;
            LoadMasterData();
        }
        public void FindAgentById()
        {
            try
            {
                if (SearchAgentAccessId == String.Empty)
                {
                    throw new Exception("Please enter Id");
                }

                SelectedAgent = _chitSubscriberDataService.FindAgent(SearchAgentAccessId);
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
        public void FindChitGroupById()
        {
            try
            {
                if (SearchChitGroupAccessId == String.Empty)
                {
                    throw new Exception("Please enter Id");
                }

                SelectedChitGroup = _chitSubscriberDataService.FindGroup(SearchChitGroupAccessId);
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
        public void FindCustomerById()
        {
            try
            {
                if (SearchAgentAccessId == String.Empty)
                {
                    throw new Exception("Please enter Id");
                }

                SelectedAgent = _agentList.First(x => x.AccessId == SearchAgentAccessId);
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
        public void LoadSubscriber(Guid keyId)
        {
           var subscriber= _chitSubscriberDataService.Get(keyId);
            _editMode = true;
            SetSubcriber(subscriber);
        }
        
    }
}
