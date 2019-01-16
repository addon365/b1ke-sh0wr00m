using BikeShowRoom.WPF.Enquiries;
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
using ViewModel.Inventory;

namespace BikeShowRoom.WPF.Inventory
{
    /// <summary>
    /// Interaction logic for ucPurchase.xaml
    /// </summary>
    public partial class ucPurchase : Window
    {
        public ucPurchase()
        {
            InitializeComponent();
            var vm = new PurchaseViewModel();
            vm.msgbox = new CustomMessageBox();
            this.DataContext = vm;
        }
    }
}
