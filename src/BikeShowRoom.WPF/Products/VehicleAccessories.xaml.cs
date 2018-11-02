using System.Windows;
using ViewModel;

namespace BikeShowRoom.WPF.Products
{
    /// <summary>
    /// Interaction logic for ProductListWindow.xaml
    /// </summary>
    public partial class VehicleAccessories : Window
    {
        VehicleAccessoriesViewModel viewmodel;
        public VehicleAccessories()
        {
            InitializeComponent();
            viewmodel = new VehicleAccessoriesViewModel();
            base.DataContext = viewmodel;
        }
    }
}
