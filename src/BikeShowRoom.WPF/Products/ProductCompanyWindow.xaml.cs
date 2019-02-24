using System.Windows;
using addon365.UI.ViewModel;

namespace addon365.UI.WPF.Products
{
    /// <summary>
    /// Interaction logic for ProductInsertWindow.xaml
    /// </summary>
    public partial class ProductCompanyWindow : Window
    {
        ProductCompanyViewModel ViewModel;
        public ProductCompanyWindow()
        {
            InitializeComponent();
            ViewModel = new ProductCompanyViewModel();
            ViewModel.InsertCommand.IsEnabled = true;
            base.DataContext = ViewModel;
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
           this.Hide();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
