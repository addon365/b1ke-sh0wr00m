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

namespace BikeShowRoom.WPF.Enquiries
{
    /// <summary>
    /// Interaction logic for ProductInsertWindow.xaml
    /// </summary>
    public partial class EnquiriesTypeWindow : Window
    {
        ProductViewModel viewmodel;
        public EnquiriesTypeWindow()
        {
            InitializeComponent();
            viewmodel = new ProductViewModel();
            viewmodel.InsertCommand.IsEnabled = true;
            base.DataContext = viewmodel;
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
           this.Hide();
        }

      
    }
}
