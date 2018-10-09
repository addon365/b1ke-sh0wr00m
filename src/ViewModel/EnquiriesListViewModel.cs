using Api.Database.Entity.Enquiries;
using Api.Domain.Enquiries;
using Swc.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    class EnquiriesListViewModel : ViewModelBase
    {
        private readonly IEnquiriesService _repository;
        private IEnumerable<Enquiry> _enquiries;
        public EnquiriesListViewModel()
        {
            _repository = new addon.BikeShowRoomService.WebService.EnquiriesService();

            Enquiries = _repository.GetAllActive();

        }
        public IEnumerable<Enquiry> Enquiries
        {
            get
            {
                return _enquiries;
            }

            set
            {
                if (_enquiries != value)
                {
                    _enquiries = value;
                    OnPropertyChanged("Enquiries");

                }
            }
        }
    }
}
