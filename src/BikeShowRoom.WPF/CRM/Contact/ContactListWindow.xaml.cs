using Syncfusion.UI.Xaml.Grid;
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
using ViewModel.Crm;

namespace BikeShowRoom.WPF.CRM.Contact
{
    /// <summary>
    /// Interaction logic for ContactListWindow.xaml
    /// </summary>
    public partial class ContactListWindow : Window
    {
        ContactViewModel viewModel;
        public ContactListWindow()
        {
            InitializeComponent();
            viewModel = new ContactViewModel();
            base.DataContext = viewModel;
        }

        private void SfDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SfDataGrid sfDataGrid = (SfDataGrid)sender;
            FollowUp followUp = new FollowUp(sfDataGrid.SelectedItem);
            followUp.ShowDialog();
        }
    }
}
