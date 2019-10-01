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

namespace addon365.UI.WPF.Enquiries
{
    /// <summary>
    /// Interaction logic for EnquriesTypeListWindow.xaml
    /// </summary>
    public partial class EnquriesTypeListWindow : Window
    {
        EnquiryTypeViewModel ViewModel;
        public EnquriesTypeListWindow()
        {
            InitializeComponent();
            ViewModel = new EnquiryTypeViewModel();
            base.DataContext = ViewModel;
            ViewModel.DeleteCommand.IsEnabled = true;
        }

        private void deletebtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
