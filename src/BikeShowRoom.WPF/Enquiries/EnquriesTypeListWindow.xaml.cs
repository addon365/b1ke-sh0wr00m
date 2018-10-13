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
    /// Interaction logic for EnquriesTypeListWindow.xaml
    /// </summary>
    public partial class EnquriesTypeListWindow : Window
    {
        EnquiryTypeViewModel viewmodel;
        public EnquriesTypeListWindow()
        {
            InitializeComponent();
            viewmodel = new EnquiryTypeViewModel();
            base.DataContext = viewmodel;
            viewmodel.DeleteCommand.IsEnabled = true;
        }

        private void deletebtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
