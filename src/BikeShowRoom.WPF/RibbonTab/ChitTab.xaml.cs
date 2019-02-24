#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using addon365.UI.WPF.Chit;
using addon365.UI.WPF.Chit.Reports;
using Syncfusion.Windows.Tools.Controls;
using System.Windows;
namespace addon365.UI.WPF
{
    /// <summary>
    /// Interaction logic for Folder.xaml
    /// </summary>
    public partial class ChitTab : RibbonTab
    {
        public ChitTab()
        {
            InitializeComponent();
        }

        private void NewChitScheme_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NewSchemaWindow newSchemaWindow = new NewSchemaWindow();
            newSchemaWindow.ShowDialog();
        }

        private void NewSubscribe_Click(object sender, RoutedEventArgs e)
        {
            NewSubscriberWindow newSubscriberWindow = new NewSubscriberWindow();
            newSubscriberWindow.ShowDialog();
        }

        private void DuePayment_Click(object sender, RoutedEventArgs e)
        {
            DuePaymentWindow duePaymentWindow = new DuePaymentWindow();
            duePaymentWindow.ShowDialog();
        }

        private void FindCustomerSubscriptions_Click(object sender, RoutedEventArgs e)
        {
            FindSubscriptionsWindow findSubscriptin = new FindSubscriptionsWindow();
            findSubscriptin.ShowDialog();
        }
        private void CloseSubscription_Click(object sender, RoutedEventArgs e)
        {
            CloseSubscription findSubscriptin = new CloseSubscription();
            findSubscriptin.ShowDialog();
        }

        private void SubscriptionReport_Click(object sender, RoutedEventArgs e)
        {
            SubscriberReportWindow subWindow = new SubscriberReportWindow();
            subWindow.ShowDialog();
        }
    }
}
