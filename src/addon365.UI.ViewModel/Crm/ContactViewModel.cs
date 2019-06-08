using addon365.Database.Entity.Crm;
using addon365.Database.Service.Crm;
using addon365.IService.Crm;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace addon365.UI.ViewModel.Crm
{
    public class ContactViewModel : ViewModelBase
    {
        private readonly IContactService _repository;
        private IEnumerable<Contact> _contacts;
        private Contact _currentContact;
        private Result onResult;

        public ContactViewModel(Result onResult = null)
        {
            this.onResult = onResult;
            var Scope = Startup.Instance.provider.CreateScope();

            _repository = Scope.ServiceProvider.GetRequiredService<IContactService>(); 
            Contacts = _repository.GetContacts();
            WireCommands();
        }

        private void WireCommands()
        {
            FollowUpOpenCommand = new RelayCommand(OpenFollowUp);
        }

        private void OpenFollowUp()
        {
            onResult(true, null, CurrentContact);
        }

        public RelayCommand FollowUpOpenCommand
        {
            get;
            private set;
        }
        public Contact CurrentContact
        {
            get
            {
                return _currentContact;
            }
            set
            {
                if (CurrentContact != value)
                {
                    _currentContact = value;
                    OnPropertyChanged("CurrentContact");
                    FollowUpOpenCommand.IsEnabled = true;
                }
            }
        }
        public IEnumerable<Contact> Contacts
        {
            get
            {
                return _contacts;
            }
            set
            {
                if (Contacts != value)
                {
                    _contacts = value;
                    OnPropertyChanged("Contacts");
                }
            }

        }
    }
}
