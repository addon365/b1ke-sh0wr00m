using addon365.WebClient.Service.WebService;
using addon365.Database.Entity.Enquiries;
using System;
using System.Collections.Generic;
using System.Text;

namespace addon365.UI.ViewModel
{
   public class EnquiryTypeViewModel: ViewModelBase
    {
        private readonly EnquiryTypeService _repositoryEnquiryType;
        private EnquiryType _currentEnquiryType;

        public EnquiryTypeViewModel()
        {
            _currentEnquiryType = new EnquiryType();
            _repositoryEnquiryType = new EnquiryTypeService();
            EnquiryTypes = _repositoryEnquiryType.GetAllEnquiryType();
            WireCommands();
        }
        private void WireCommands()
        {

            InsertCommand = new RelayCommand(AddEnquiryType);
            DeleteCommand = new RelayCommand(DeleteEnquiryType);
        }
        public RelayCommand InsertCommand
        {
            get;
            private set;
        }
        public RelayCommand DeleteCommand
        {
            get;
            private set;
        }
        public IEnumerable<EnquiryType> EnquiryTypes { get; set; }
        public EnquiryType CurrentEnquiryType
        {
            get
            {
                return _currentEnquiryType;
            }

            set
            {

                _currentEnquiryType = value;
                OnPropertyChanged("CurrentEnquiryType");
                InsertCommand.IsEnabled = true;


            }
        }
        public void AddEnquiryType()
        {
            _repositoryEnquiryType.Insert(CurrentEnquiryType);
        }
        public void DeleteEnquiryType()
        {
            EnquiryType p = CurrentEnquiryType;
            _repositoryEnquiryType.Delete(p);

        }
    }
}
