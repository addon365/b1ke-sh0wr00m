using System.Windows;
using addon365.UI.ViewModel.Crm;

namespace addon365.UI.WPF.CRM
{
    /// <summary>
    /// Interaction logic for FollowUp.xaml
    /// </summary>
    public partial class FollowUp : Window
    {
        FollowUpViewModel ViewModel;
        public FollowUp(object ViewModel)
        {
            InitializeComponent();
            FollowUpViewModel followUpViewModel = (FollowUpViewModel)ViewModel;
            followUpViewModel.OnResult = CloseMe;
            base.DataContext = ViewModel;
        }
        public void CloseMe(bool isSuccess, string message, object data)
        {
            ContactWindow.OnResult(isSuccess, message);
            this.Close();
        }

    }
}
