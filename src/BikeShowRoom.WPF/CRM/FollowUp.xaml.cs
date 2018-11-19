using System.Windows;
using ViewModel.Crm;

namespace BikeShowRoom.WPF.CRM
{
    /// <summary>
    /// Interaction logic for FollowUp.xaml
    /// </summary>
    public partial class FollowUp : Window
    {
        FollowUpViewModel viewmodel;
        public FollowUp(object viewmodel)
        {
            InitializeComponent();
            FollowUpViewModel followUpViewModel = (FollowUpViewModel)viewmodel;
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
