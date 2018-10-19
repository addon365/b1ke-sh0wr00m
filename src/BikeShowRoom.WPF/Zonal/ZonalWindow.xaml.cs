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

namespace BikeShowRoom.WPF.Zonal
{
    /// <summary>
    /// Interaction logic for ZonalWindow.xaml
    /// </summary>
    public partial class ZonalWindow : Window
    {
        ZonalViewModel viewmodel;
        public ZonalWindow()
        {
            InitializeComponent();
            viewmodel = new ZonalViewModel();
            viewmodel.InsertCommand.IsEnabled = true;
            base.DataContext = viewmodel;
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
