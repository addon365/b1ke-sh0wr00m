using System.Windows;
using addon365.UI.ViewModel.Chit;

namespace addon365.UI.WPF.Chit
{
    /// <summary>
    /// Interaction logic for DuePaymentWindow.xaml
    /// </summary>
    public partial class DuePaymentWindow : Window
    {
        private ChitDueViewModel chitDueViewModel;
        public DuePaymentWindow()
        {
            InitializeComponent();
            chitDueViewModel = new ChitDueViewModel();
            base.DataContext = chitDueViewModel;

        }

       
    }
}
