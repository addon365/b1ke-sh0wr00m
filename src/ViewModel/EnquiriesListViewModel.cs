using Api.Database.Entity.Enquiries;
using Api.Domain.Enquiries;
using Swc.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel
{
    public class EnquiriesListViewModel : ViewModelBase
    {
        private readonly IEnquiriesService _repository;
        private IEnumerable<Enquiries> _enquiries;
        public EnquiriesListViewModel()
        {
            _repository = new addon.BikeShowRoomService.WebService.EnquiriesService();

            _enquiries = _repository.GetAllActive();

        }
        public IEnumerable<Enquiries> Enquiries
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
