﻿using Api.Database.Entity;
using Api.Database.Entity.Enquiries;
using Api.Database.Entity.Products;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ViewModel;
using ViewModel.Sales;

namespace BikeShowRoom.WPF.Sales
{
    /// <summary>
    /// Interaction logic for Enquiries.xaml
    /// </summary>
    public partial class VechicleSale : Window
    {
     
       
        public VechicleSale()
        {
            InitializeComponent();
            var vm= new SalesViewModel();
          
            this.DataContext = vm;

            vm.MsgBox = new MessageBoxClass();
            

          
            
        }


    }

    public class MessageBoxClass : IMsgBox
    {
        public void ShowUI(string msg)
        {
            MessageBox.Show(msg);
        }
    }
}