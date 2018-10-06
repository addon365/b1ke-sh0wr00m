using Api.Database.Entity.Products;
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

namespace BikeShowRoom.WPF
{
   
    /// <summary>
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    /// 
    public partial class ProductWindow : Window
    {
        public static DataGrid datagrid;
        List<Product> products;
        public ProductWindow()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            products = new List<Product>();
            products.Add(new Product { Id = Guid.NewGuid(), ProductName = "Hero Spleder Plus", Price = 53700 });
            products.Add(new Product { Id = Guid.NewGuid(), ProductName = "Bajaji Pulsor", Price = 86020 });
            products.Add(new Product { Id = Guid.NewGuid(), ProductName = "Bajaji CD 100", Price = 45090 });
            products.Add(new Product { Id = Guid.NewGuid(), ProductName = "Honda Activa", Price = 56300 });
            myDataGrid.ItemsSource = products;
            datagrid = myDataGrid;
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            Guid Id = (myDataGrid.SelectedItem as Product).Id;
            ProductEditWindow edit = new ProductEditWindow(Id);
            edit.ShowDialog();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Guid Id= (myDataGrid.SelectedItem as Product).Id;
            //var deleteproduct=
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            ProductInsertWindow insert = new ProductInsertWindow();
            insert.ShowDialog();
        }
    }
}
