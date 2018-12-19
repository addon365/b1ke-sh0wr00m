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
    public partial class EnquriesListWindow : Window
    {
        EnquiriesListViewModel viewmodel;
        public EnquriesListWindow()
        {
            InitializeComponent();
            viewmodel = new EnquiriesListViewModel();
            base.DataContext = viewmodel;
            viewmodel.ReportObj = new Reports();
            viewmodel.OpenBooking = OpenBooking;
            
        }
        public void OpenBooking(Enquiry enquiries)
        {
            EnquiryBookingViewModel enquiryBookingViewModel = new EnquiryBookingViewModel(enquiries);
            EnquiryBooking eb = new EnquiryBooking(enquiryBookingViewModel);
            eb.ShowDialog();
        }
    }

    public class Reports : ICrystalReport
    {
        public void ShowReport(ReportDocument rep)
        {
            ReportViewer rpt = new ReportViewer(rep);
            rpt.ShowDialog();
            
        }
    }
}
