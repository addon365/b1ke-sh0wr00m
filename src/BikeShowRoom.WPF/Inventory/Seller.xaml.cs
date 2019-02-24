﻿using addon365.UI.WPF.Enquiries;
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
using addon365.UI.ViewModel.Inventory;

namespace addon365.UI.WPF.Inventory
{
    /// <summary>
    /// Interaction logic for ucPurchase.xaml
    /// </summary>
    public partial class SellerWindow : Window
    {
        public SellerWindow()
        {
            InitializeComponent();
            var vm = new SellerViewModel();
            vm.MessageBox = new CustomMessageBox();
            this.DataContext = vm;
        }

    }
}
