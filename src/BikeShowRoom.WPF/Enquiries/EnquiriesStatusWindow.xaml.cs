﻿using System;
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
    /// Interaction logic for ProductInsertWindow.xaml
    /// </summary>
    public partial class EnquiriesStatusWindow : Window
    {
        ProductViewModel ViewModel;
        public EnquiriesStatusWindow()
        {
            InitializeComponent();
            ViewModel = new ProductViewModel();
            ViewModel.InsertCommand.IsEnabled = true;
            base.DataContext = ViewModel;
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
           this.Hide();
        }

      
    }
}
