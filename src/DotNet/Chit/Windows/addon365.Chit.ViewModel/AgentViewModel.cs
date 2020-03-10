

using addon365.Chit.DomainEntity;
using addon365.Chit.DataService;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows.Input;

namespace addon365.Chit.ViewModel
{
    public class AgentViewModel : ViewModelBase
    {
        private IAgentDataService _agentDataService;
        Guid _keyId;
        string _title, _accessId, _firstName,_lastName;
        private bool _editMode = false;

        public AgentViewModel(IAgentDataService agentDataService)
        {
            try
            { 
            this._agentDataService = agentDataService;
            if (IsInDesignMode)
            {
                Title = "Hello MVVM Light (Design Mode)";
            }
            else
            {
                Title = "Hello MVVM Light";
                LoadMasterData();
                
            }

                SaveAgentCommand = new RelayCommand(SaveAgent,CanSaveAgent,true);
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
        public RelayCommand SaveAgentCommand { get; private set; }
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
                ((RelayCommand)SaveAgentCommand).RaiseCanExecuteChanged();
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
        public bool CanSaveAgent()
        {
            if (string.IsNullOrEmpty(FirstName))
                return false;

            return true;
        }
            public void SaveAgent()
        {
            try
            { 
                 AgentModel agentModel = GetCurrentAgent();
            
                if (_editMode == false)
                {
                    _agentDataService.Insert(agentModel);
                }
                else
                {
                    agentModel.KeyId = this.KeyId;
                    _agentDataService.Update(agentModel);
                    
                }
                
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Agent Saved."));
                Clear();
                LoadMasterData();

            }
            catch(Exception ex)
            {

                while(ex.InnerException!=null)
                {
                    ex = ex.InnerException;
                }
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ex.Message));
            }
        }
        private AgentModel GetCurrentAgent()
        {
            
            return new AgentModel {AccessId=this.AccessId,FirstName=this.FirstName,LastName=this.LastName};
        }
     
        public void LoadMasterData()
        {
            var masterData = _agentDataService.GetMasterData();
            Int64 id = 1;
            if (masterData.MaxAccessId != null && masterData.MaxAccessId != "")
                id = Convert.ToInt64(masterData.MaxAccessId) + 1;

            AccessId = id.ToString();
        }
        public void LoadAgent(Guid keyId)
        {
            var agent = _agentDataService.Get(keyId);
            _editMode = true;
            SetGroup(agent);
        }
        private void SetGroup(AgentModel agentModel)
        {
            KeyId = agentModel.KeyId;
            AccessId = agentModel.AccessId;
            FirstName = agentModel.FirstName;
            LastName = agentModel.LastName;

        }
        private void Clear()
        {
            AccessId = string.Empty;
            FirstName = String.Empty;
            LastName = string.Empty;
        }
        
    }
}
