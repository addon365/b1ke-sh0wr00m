using addon365.UI.WPF.Settings;
using System.Windows;
using addon365.UI.ViewModel;
using addon365.UI.ViewModel.Enquiries;

namespace addon365.UI.WPF.Enquiries
{
    /// <summary>
    /// Interaction logic for FollowUp.xaml
    /// </summary>
    public partial class EnquiryBooking : Window
    {
        EnquiryBookingViewModel ViewModel1;
        public EnquiryBooking(object ViewModel)
        {
            InitializeComponent();
            
            EnquiryBookingViewModel ViewModel1 = (EnquiryBookingViewModel)ViewModel;
            
           ViewModel1.OnResult = CloseMe;
            ViewModel1.msg = new CustomMessageBox();
            base.DataContext = ViewModel;
        }
        public void CloseMe(bool isSuccess, string message, object data)
        {
            ContactWindow.OnResult(isSuccess, message);
            this.Close();
        }

    }
    public class CustomMessageBox : IMsgBox
    {
        public void ShowUI(string msg)
        {
            MessageBox.Show(msg);
        }
    }
}
