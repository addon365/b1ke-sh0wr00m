using BikeShowRoom.WPF.Settings;
using System.Windows;
using ViewModel;
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
            var container = TinyIoC.TinyIoCContainer.Current;
            IConfigProvider service = container.Resolve<IConfigProvider>("App");
            EnquiryBookingViewModel ViewModel = (EnquiryBookingViewModel)viewmodel;
            
            ViewModel.OnResult = CloseMe;
            ViewModel.msg = new CustomMessageBox();
            base.DataContext = viewmodel;
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
