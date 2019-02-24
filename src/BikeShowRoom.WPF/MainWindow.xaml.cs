using addon365.Database;
using addon365.Domain.Entity.Enquiries;
using Microsoft.EntityFrameworkCore;
using addon365.Database.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Threenine.Data;
using Unity;
using addon365.UI.ViewModel;

namespace addon365.UI.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       


        public MainWindow()
        {
            InitializeComponent();
          

            //var enquir = new EnquiriesService(u);

            //var addon365.UI.ViewModel= new EnquiryViewModel();
            //addon365.UI.ViewModel.CurrentEnquiry = new Enquiries();
            //addon365.UI.ViewModel.CurrentEnquiry.Name = "Tamilselvan";
            //this.DataContext = addon365.UI.ViewModel;
        }

        
    }
}
