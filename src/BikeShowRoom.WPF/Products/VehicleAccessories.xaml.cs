using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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
