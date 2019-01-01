using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Api.Database.Entity.Enquiries;
using CrystalDecisions.CrystalReports.Engine;
using ViewModel;
using ViewModel.Enquiries;

namespace BikeShowRoom.WPF.Enquiries
{
    /// <summary>
    /// Interaction logic for ProductListWindow.xaml
    /// </summary>
    public partial class BookingListWindow : Window
    {
        EnquiriesBookingListViewModel viewmodel;
        public BookingListWindow()
        {
            InitializeComponent();
            viewmodel = new EnquiriesBookingListViewModel();
            base.DataContext = viewmodel;
            viewmodel.ReportObj = new Reports();
            viewmodel.OpenBooking = OpenBooking;
            viewmodel.Edit = Edit;

        }
        public void OpenBooking(Enquiry enquiries)
        {
            EnquiryBookingViewModel enquiryBookingViewModel = new EnquiryBookingViewModel(enquiries);
            EnquiryBooking eb = new EnquiryBooking(enquiryBookingViewModel);
            eb.ShowDialog();
        }
        public void Edit(string identifier)
        {
            EnquiryViewModel enquiryViewModel = new EnquiryViewModel(identifier);
            EnquiryWindow en = new EnquiryWindow();
            en.DataContext = enquiryViewModel;
            en.ShowDialog();
        }
    }

   
}
