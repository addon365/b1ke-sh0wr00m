using addon365.UI.WPF.Enquiries;
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
using addon365.UI.ViewModel;

namespace addon365.UI.WPF.Products
{
    /// <summary>
    /// Interaction logic for ProductListWindow.xaml
    /// </summary>
    public partial class ProductListWindow : Window
    {
        ProductListViewModel ViewModel;
        public ProductListWindow()
        {
            InitializeComponent();
            ViewModel = new ProductListViewModel();
            ViewModel.msg = new CustomMessageBox();
            base.DataContext = ViewModel;

        }
    }
}
