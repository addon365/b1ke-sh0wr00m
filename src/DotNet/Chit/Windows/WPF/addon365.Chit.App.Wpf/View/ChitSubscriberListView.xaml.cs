using addon365.Chit.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace addon365.Chit.App.Wpf.View
{
    /// <summary>
    /// Interaction logic for ChitGroupListView.xaml
    /// </summary>
    public partial class ChitSubscriberListView : Window
    {
        public ChitSubscriberListView()
        {
            InitializeComponent();
            DialogOption.Visibility = Visibility.Hidden;
        }
        public ChitSubscriberListView(bool dialogMode)
        {
            InitializeComponent();
            if(dialogMode==true)
            {
                DialogOption.Visibility = Visibility.Visible;
            }
            else
            {
                DialogOption.Visibility = Visibility.Hidden;
            }
        }


        private void btnOkay_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var vm = this.DataContext as ChitSubscriberListViewModel;
                if (vm.SelectedSubscriber == null)
                    throw new Exception("Subscriber not selected");

              ChitSubscriberView chitSubscriberView = new ChitSubscriberView(vm.SelectedSubscriber.KeyId);

                chitSubscriberView.ShowDialog();
            }
            catch (Exception ex)
            {

                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                MessageBox.Show(ex.Message);
            }
        }
        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            this.dgSubscriberList.SearchHelper.AllowFiltering = true;
            this.dgSubscriberList.SearchHelper.Search(txtSearchText.Text);
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            this.dgSubscriberList.SearchHelper.ClearSearch();
        }
    }
}
