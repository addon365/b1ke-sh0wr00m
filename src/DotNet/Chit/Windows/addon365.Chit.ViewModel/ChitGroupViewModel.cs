

using addon365.Chit.DomainEntity;
using addon365.Chit.DataService;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows.Input;

namespace addon365.Chit.ViewModel
{
    public class ChitGroupViewModel : ViewModelBase
    {
        private IChitGroupDataService _groupDataService;
        Guid _keyId;
        string _title, _accessId, _groupName;
        short _totalDues;
        Decimal _dueAmount;
        DateTime _startDate;
        private bool _editMode = false;
        public ChitGroupViewModel(IChitGroupDataService groupDataService)
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
                LoadMasterData();
                StartDate = System.DateTime.Now;
            }
            
            SaveChitGroupCommand = new RelayCommand(SaveChitGroup);
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
        public RelayCommand SaveChitGroupCommand { get; private set; }
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

        public string GroupName
        {
            get
            {
                return _groupName;
            }
            set
            {
                _groupName = value;
                RaisePropertyChanged("GroupName");
            }
        }
        public Decimal DueAmount
        {
            get
            {
                return _dueAmount;
            }
            set
            {
                _dueAmount = value;
                RaisePropertyChanged("DueAmount");
            }
        }
        public short TotalDues
        {
            get
            {
                return _totalDues;
            }
            set
            {
                _totalDues = value;
                RaisePropertyChanged("TotalDues");
            }
        }
        public DateTime StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                _startDate = value;
                RaisePropertyChanged("StartDate");
            }
        }


        public void SaveChitGroup()
        {
            try
            {
                ChitGroupModel chitGroupModel = GetCurrentGroup();

                if (_editMode == false)
                {
                    _groupDataService.Insert(chitGroupModel);
                }
                else
                {
                    chitGroupModel.KeyId = this.KeyId;
                    _groupDataService.Update(chitGroupModel);

                }
                
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Group Saved."));
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
        private ChitGroupModel GetCurrentGroup()
        {
            
            return new ChitGroupModel { AccessId=this.AccessId,GroupName = this.GroupName, ChitDueAmount=this.DueAmount,TotalDues=this.TotalDues,StartDate=this.StartDate};
        }
     
        public void LoadMasterData()
        {
           
        }
        public void LoadGroup(Guid keyId)
        {
            var group = _groupDataService.Get(keyId);
            _editMode = true;
            SetGroup(group);
        }
        private void SetGroup(ChitGroupModel chitGroupModel)
        {
            KeyId = chitGroupModel.KeyId;
            AccessId = chitGroupModel.AccessId;
            GroupName = chitGroupModel.GroupName;
            DueAmount = chitGroupModel.ChitDueAmount;
            TotalDues = chitGroupModel.TotalDues;
            
        }
        private void Clear()
        {
            AccessId = string.Empty;
            GroupName = String.Empty;
            DueAmount = 0;
        }
        
    }
}
