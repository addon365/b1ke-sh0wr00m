using System.Windows;
using BikeShowRoom.WPF.Enquiries;


namespace BikeShowRoom.WPF.Inventory
{
    /// <summary>
    /// Interaction logic for ProductListWindow.xaml
    /// </summary>
    public partial class SellerListWindow : Window
    {
        ViewModel.Inventory.SellerListViewModel viewmodel;
        public SellerListWindow()
        {
            InitializeComponent();
            viewmodel = new ViewModel.Inventory.SellerListViewModel();
            base.DataContext = viewmodel;
            viewmodel.ReportObj = new Reports();
            viewmodel.Edit = Edit;

        }
       
        public void Edit(string id)
        {
            ViewModel.Inventory.SellerViewModel ViewModel = new ViewModel.Inventory.SellerViewModel(id);
            SellerWindow en = new SellerWindow();
            en.DataContext = ViewModel;
            en.ShowDialog();
        }
    }

   
}
