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
using addon365.Database.Entity.Enquiries;
using CrystalDecisions.CrystalReports.Engine;
using addon365.UI.ViewModel;
using addon365.UI.ViewModel.Enquiries;

namespace addon365.UI.WPF.Enquiries
{
    /// <summary>
    /// Interaction logic for ProductListWindow.xaml
    /// </summary>
    public partial class EnquriesListWindow : Window
    {
        EnquiriesListViewModel ViewModel;
        public EnquriesListWindow()
        {
            InitializeComponent();
            ViewModel = new EnquiriesListViewModel();
            base.DataContext = ViewModel;
            ViewModel.ReportObj = new Reports();
            ViewModel.OpenBooking = OpenBooking;
            ViewModel.Edit = Edit;

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

    public class Reports : ICrystalReport
    {
        public void ShowReport(ReportDocument rep)
        {
            ReportViewer rpt = new ReportViewer(rep);
            rpt.ShowDialog();
            
        }
    }
}
