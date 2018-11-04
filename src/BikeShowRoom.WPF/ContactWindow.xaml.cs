#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace BikeShowRoom.WPF
{
    /// <summary>
    /// Interaction logic for ContactWindow.xaml
    /// </summary>
    public partial class ContactWindow : RibbonWindow
    {
        private static ContactWindow _contactWindow;
        public ContactWindow()
        {
            InitializeComponent();
            RemoveGroupBarOverFlowButton();
            _contactWindow = this;
            popUpMessage.IsOpen = false;
        }
		
        public void RemoveGroupBarOverFlowButton()
        {
            foreach (ToggleButton item in VisualUtils.EnumChildrenOfType(groupBar, typeof(ToggleButton)))
            {
                if (item.Name == "PART_OverFlowButton")
                {
                    item.Visibility = Visibility.Collapsed;
                }
            }
        }
        public static void OnResult(bool isSuccess, string message)
        {
            _contactWindow.ShowPopUp(isSuccess,message);
        }
        public void ShowPopUp(bool isSuccess,string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                DispatcherTimer dispatcherTimer = new DispatcherTimer();
                dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
                popUpMessage.IsOpen = true;
                popUpText.Text = message;
                dispatcherTimer.Start();
            }
           
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            popUpMessage.IsOpen = false;
        }
    }
}
