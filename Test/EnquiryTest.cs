using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewModel;

namespace ViewModel
{
    [TestClass]
    public class EnquiryTest
    {
        [TestMethod]
        public void InsertTest()
        {
            EnquiryViewModel enquiryViewModel = new EnquiryViewModel();
            enquiryViewModel.CurrentEnquiry = new Models.Enquiry() { EnquiryId = 4, Name = "Tamil Selvan", MobileNumber = "9894496128", Place = "Walaja" };
            enquiryViewModel.InsertEnquiry();
            enquiryViewModel.CurrentEnquiry = new Models.Enquiry() { MobileNumber = "9894496128" };
            enquiryViewModel.FindEnquiry();

            Assert.AreEqual(4, enquiryViewModel.CurrentEnquiry.EnquiryId);
            Assert.AreEqual("Tamil Selvan", enquiryViewModel.CurrentEnquiry.Name);

        }
    }
}
