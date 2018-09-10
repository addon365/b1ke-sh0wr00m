using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace ViewModel
{
    public class EnquiryRepository
    {
        private List<Enquiry> _enquiries;
        HttpClient httpClient;
        public EnquiryRepository()
        {
          
        }

        public List<Enquiry> GetEnquiries()
        {
            return _enquiries;
        }

        public void UpdateEnquiry(Enquiry selectedEnquiry)
        {
            
            Enquiry enquiryToChange = _enquiries.Single(c => c.EnquiryId == selectedEnquiry.EnquiryId);
            enquiryToChange = selectedEnquiry;
        }

        internal void InsertEnquiry(Enquiry currentEnquiry)
        {
            _enquiries.Add(currentEnquiry);
        }

        internal Enquiry FindEnquiry(Enquiry currentEnquiry)
        { 
           return _enquiries.Single(c => c.MobileNumber == currentEnquiry.MobileNumber);
        }
    }

}
