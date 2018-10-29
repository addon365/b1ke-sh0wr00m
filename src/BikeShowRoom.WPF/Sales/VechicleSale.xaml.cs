using Api.Database.Entity;
using Api.Database.Entity.Enquiries;
using Api.Database.Entity.Products;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ViewModel;

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
            var vm= new EnquiryViewModel();
          
            this.DataContext = vm;
   
            

          
            
        }


    }
}
