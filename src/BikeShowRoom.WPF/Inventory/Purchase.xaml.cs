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
using ViewModel;
using ViewModel.Inventory;

namespace BikeShowRoom.WPF.Inventory
{
    /// <summary>
    /// Interaction logic for ucPurchase.xaml
    /// </summary>
    public partial class Purchase : Window,IViewUI<PropertyValueViewModel>
    {
        public Purchase()
        {
            InitializeComponent();
            var vm = new PurchaseViewModel();
            vm.MessageBox = new CustomMessageBox();
            vm.PropertyWindow = this;
            this.DataContext = vm;
        }

        public void ShowUI(PropertyValueViewModel Model)
        {
            PropertyValue propertyValue = new PropertyValue(Model);
            propertyValue.ShowDialog();
        }
    }
}
