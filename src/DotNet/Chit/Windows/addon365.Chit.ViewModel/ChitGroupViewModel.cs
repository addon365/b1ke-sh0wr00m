

using addon365.Chit.DomainEntity;
using addon365.Chit.IDataService;
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
        public ChitGroupViewModel(IChitGroupDataService groupDataService)
        {
            if (IsInDesignMode)
            {
                Title = "Hello MVVM Light (Design Mode)";
            }
            else
            {
                Title = "Hello MVVM Light";
            }
            this._groupDataService = groupDataService;
            SaveChitGroupCommand = new RelayCommand(SaveChitGroup);
        }
        public ICommand SaveChitGroupCommand { get; private set; }
        public string Title { get; set; }
        public string GroupName { get; set; }
        public Decimal Amount { get; set; }
        public void LoadMasterData()
        {

        }

        public void SaveChitGroup()
        {
            try
            {
            
                _groupDataService.Insert(GetCurrentGroup());
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Group Saved."));
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
            
            return new ChitGroupModel { GroupName = this.GroupName, Amount=this.Amount};
        }
     
        public void LoadSubscriber()
        {

        }
        
    }
}
