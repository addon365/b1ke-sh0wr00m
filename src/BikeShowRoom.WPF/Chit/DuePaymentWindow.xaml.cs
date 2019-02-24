using System.Windows;
using ViewModel.Chit;

namespace BikeShowRoom.WPF.Chit
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
