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
    public class AgentListViewModel : ViewModelBase
    {
        private IAgentListDataService _agentDataService;
        private ObservableCollection<AgentModel> _agentList;
        private AgentModel _selectedAgent;
        public AgentListViewModel(IAgentListDataService agentDataService)
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
                    LoadMethod();
                }

                DeleteAgentCommand = new RelayCommand(DeleteAgent);
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
        public RelayCommand DeleteAgentCommand { get; private set; }
        public string Title { get; set; }

        public ObservableCollection<AgentModel> AgentList
        {
            get
            {
                return _agentList;
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
        private void LoadMethod()
        {
            _agentList = new ObservableCollection<AgentModel>(_agentDataService.GetAll());
            this.RaisePropertyChanged(() => this.AgentList);
    
        }
        void DeleteAgent()
        {
            try
            {
                _agentDataService.Delete(SelectedAgent.KeyId);
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
