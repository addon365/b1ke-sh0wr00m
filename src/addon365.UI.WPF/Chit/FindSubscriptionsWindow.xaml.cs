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
using addon365.UI.ViewModel.Chit;

namespace addon365.UI.WPF.Chit
{
    /// <summary>
    /// Interaction logic for FindSubscriptionsWindow.xaml
    /// </summary>
    public partial class FindSubscriptionsWindow : Window
    {
        public FindSubscriptionsWindow()
        {
            InitializeComponent();
            var ViewModel = new FindSubscriptionViewModel();
            base.DataContext = ViewModel;
        }
    }
}
