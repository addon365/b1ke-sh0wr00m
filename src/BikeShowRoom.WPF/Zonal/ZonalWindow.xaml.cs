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

namespace addon365.UI.WPF.Zonal
{
    /// <summary>
    /// Interaction logic for ZonalWindow.xaml
    /// </summary>
    public partial class ZonalWindow : Window
    {
        ZonalViewModel ViewModel;
        public ZonalWindow()
        {
            InitializeComponent();
            ViewModel = new ZonalViewModel();
            ViewModel.InsertCommand.IsEnabled = true;
            base.DataContext = ViewModel;
        }

        private void insertButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
        
    }
}
