
using Api.Database.Entity;
using Api.Database.Entity.Enquiries;
using Api.Database.Entity.Products;
using Api.Domain.Enquiries;
using Swc.Service;
using System;
using System.Collections.Generic;
using Threenine.Data;

namespace ViewModel
{
    public class EnquiryViewModel : ViewModelBase
    {
        private readonly IEnquiriesService _repository;
        private  Enquiries _currentEnquiry;
        private MarketingZone _currentMarketingZone;

        public EnquiryViewModel()
        {
            _repository = new addon.BikeShowRoomService.WebService.EnquiriesService();

            EnquiryMasterData=_repository.GetInitilizeEnquiries();
            WireCommands();
        }

        private void WireCommands()
        {
            UpdateEnquiryCommand = new RelayCommand(UpdateEnquiry);
            InsertEnquiryCommand = new RelayCommand(InsertEnquiry);
            FindEnquiryCommand = new RelayCommand(FindEnquiry);
        }
        public InitilizeEnquiry EnquiryMasterData { get; }
        IEnumerable<MarketingZone> lstMarketingZone { get; set; }
        IEnumerable<Product> lstProducts { get; set; }
        IEnumerable<ExtraFittingsAccessories> lstExtraAccessories { get; set; }
        IEnumerable<EnquiryType> enquiryTypes { get; set; }
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
       public MarketingZone CurrentMarketingZone
        {
            get
            {
                return _currentMarketingZone;
            }

            set
            {
                if (_currentMarketingZone != value)
                {
                    _currentMarketingZone = value;
                    OnPropertyChanged("MarketingZone");
                   
                }
            }
        }

        public Enquiries CurrentEnquiry
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
           
        }
        public void InsertEnquiry()
        {
            
            InsertEnquiry ie = new InsertEnquiry();
            ie.enquiries = CurrentEnquiry;

            _repository.Insert(ie);
        }
        public void FindEnquiry()
        {
            
        }
    }

 
}
