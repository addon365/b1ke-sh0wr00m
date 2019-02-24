using System.Windows;
using addon365.UI.WPF.Enquiries;


namespace addon365.UI.WPF.Inventory
{
    /// <summary>
    /// Interaction logic for ProductListWindow.xaml
    /// </summary>
    public partial class SellerListWindow : Window
    {
        addon365.UI.ViewModel.Inventory.SellerListViewModel ViewModel;
        public SellerListWindow()
        {
            InitializeComponent();
           ViewModel = new addon365.UI.ViewModel.Inventory.SellerListViewModel();
            base.DataContext = ViewModel;
            ViewModel.ReportObj = new Reports();
            ViewModel.Edit = Edit;

        }
       
        public void Edit(string id)
        {
            addon365.UI.ViewModel.Inventory.SellerViewModel ViewModel = new addon365.UI.ViewModel.Inventory.SellerViewModel(id);
            SellerWindow en = new SellerWindow();
            en.DataContext = ViewModel;
            en.ShowDialog();
        }
    }

   
}
