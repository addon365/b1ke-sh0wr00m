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
    /// Interaction logic for ZonalListWindow.xaml
    /// </summary>
    public partial class ZonalListWindow : Window
    {
        ZonalViewModel viewmodel;
        public ZonalListWindow()
        {
            InitializeComponent();
            viewmodel = new ZonalViewModel();
            base.DataContext = viewmodel;
            viewmodel.DeleteCommand.IsEnabled = true;
        }
        public void Deletebtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
