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
    /// Interaction logic for ProductCompanyListWindow.xaml
    /// </summary>
    public partial class ProductCompanyListWindow : Window
    {
        ProductCompanyViewModel viewmodel;
        public ProductCompanyListWindow()
        {
            InitializeComponent();
            viewmodel = new ProductCompanyViewModel();
            base.DataContext = viewmodel;
            viewmodel.DeleteCommand.IsEnabled = true;
        }

        public void Deletebtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
