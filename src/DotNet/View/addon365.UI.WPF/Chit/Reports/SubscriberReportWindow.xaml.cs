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
using addon365.UI.ViewModel.Chit.Reports;

namespace addon365.UI.WPF.Chit.Reports
{
    /// <summary>
    /// Interaction logic for SubscriberReportWindow.xaml
    /// </summary>
    public partial class SubscriberReportWindow : Window
    {
        private SubscriberReportViewModel ViewModel;
        public SubscriberReportWindow()
        {
            InitializeComponent();
            ViewModel = new SubscriberReportViewModel();
            this.DataContext = ViewModel;
        }
    }
}
