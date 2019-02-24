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
using addon365.UI.ViewModel;
using addon365.UI.ViewModel.Crm;

namespace addon365.UI.WPF.CRM.Contact
{
    /// <summary>
    /// Interaction logic for ContactListWindow.xaml
    /// </summary>
    public partial class ContactListWindow : Window
    {
        ContactViewModel ViewModel;
        public ContactListWindow()
        {
            InitializeComponent();
            ViewModel = new ContactViewModel(ShowUI);
            base.DataContext = ViewModel;
        }

        public void ShowUI(bool success,string message,object data)
        {
            FollowUpViewModel followUpViewModel = new FollowUpViewModel(data, null);
            FollowUp followUp = new FollowUp(followUpViewModel);
            followUp.ShowDialog();
        }

       
    }
}
