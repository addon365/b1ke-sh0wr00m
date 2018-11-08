using Api.Database.Entity.Crm;
using Swc.Service.Crm;
using System;
using System.Collections.Generic;

namespace ViewModel.Crm
{
    public class ContactViewModel : ViewModelBase
    {
        private readonly IContactService _repository;
        private IEnumerable<Contact> _contacts;
        public ContactViewModel(Result onResult = null)
        {
            _repository = new addon.BikeShowRoomService.WebService.ContactService();
            Contacts = _repository.GetContacts();
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
