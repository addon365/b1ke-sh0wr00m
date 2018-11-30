using System.Windows;
using ViewModel.Enquiries;

namespace BikeShowRoom.WPF.Enquiries
{
    /// <summary>
    /// Interaction logic for FollowUp.xaml
    /// </summary>
    public partial class EnquiryBooking : Window
    {
        EnquiryBookingViewModel viewmodel;
        public EnquiryBooking(object viewmodel)
        {
            InitializeComponent();
            EnquiryBookingViewModel followUpViewModel = (EnquiryBookingViewModel)viewmodel;
            followUpViewModel.OnResult = CloseMe;
            base.DataContext = viewmodel;
        }
        public void CloseMe(bool isSuccess, string message, object data)
        {
            ContactWindow.OnResult(isSuccess, message);
            this.Close();
        }

    }
}
