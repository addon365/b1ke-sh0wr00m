using System.Windows;
using addon365.UI.ViewModel;

namespace addon365.UI.WPF.Products
{
    /// <summary>
    /// Interaction logic for ProductListWindow.xaml
    /// </summary>
    public partial class VehicleAccessories : Window
    {
        VehicleAccessoriesViewModel ViewModel;
        public VehicleAccessories()
        {
            InitializeComponent();
            ViewModel = new VehicleAccessoriesViewModel();
            base.DataContext = ViewModel;
        }
    }
}
