using Models;
using System;
using System.Collections.Generic;

namespace ViewModel
{
    public class EnquiryViewModel : ViewModelBase
    {
        private List<Enquiry> _enquiries;
        private Enquiry _currentEnquiry;
        private EnquiryRepository _repository;

        public EnquiryViewModel()
        {
            _repository = new EnquiryRepository();
            _enquiries = _repository.GetEnquiries();

            WireCommands();
        }

        private void WireCommands()
        {
            UpdateEnquiryCommand = new RelayCommand(UpdateEnquiry);
            InsertEnquiryCommand = new RelayCommand(InsertEnquiry);
            FindEnquiryCommand = new RelayCommand(FindEnquiry);
        }

        public RelayCommand UpdateEnquiryCommand
        {
            get;
            private set;
        }
        public RelayCommand InsertEnquiryCommand
        {
            get;
            private set;
        }
        public RelayCommand FindEnquiryCommand
        {
            get;
            private set;
        }
        public List<Enquiry> Enquiries
        {
            get { return _enquiries; }
            set { _enquiries = value; }
        }

        public Enquiry CurrentEnquiry
        {
            get
            {
                return _currentEnquiry;
            }

            set
            {
                if (_currentEnquiry != value)
                {
                    _currentEnquiry = value;
                    OnPropertyChanged("CurrentEnquiry");
                    InsertEnquiryCommand.IsEnabled = true;
                    FindEnquiryCommand.IsEnabled = true;
                    UpdateEnquiryCommand.IsEnabled = true;
                }
            }
        }

        public void UpdateEnquiry()
        {
            _repository.UpdateEnquiry(CurrentEnquiry);
        }
        public void InsertEnquiry()
        {
            _repository.InsertEnquiry(CurrentEnquiry);
        }
        public void FindEnquiry()
        {
            CurrentEnquiry = _repository.FindEnquiry(CurrentEnquiry);
        }
    }

 
}
