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
using ViewModel;
using ViewModel.Crm;

namespace BikeShowRoom.WPF.CRM
{
    /// <summary>
    /// Interaction logic for FollowUp.xaml
    /// </summary>
    public partial class FollowUp : Window
    {
        FollowUpViewModel viewmodel;
        public FollowUp(object contact)
        {
            InitializeComponent();
            viewmodel = new FollowUpViewModel(contact,CloseMe);
            base.DataContext = viewmodel;
        }
        public void CloseMe(bool isSuccess,string message)
        {
            ContactWindow.OnResult(isSuccess, message);
            this.Close();
        }
       
    }
}
