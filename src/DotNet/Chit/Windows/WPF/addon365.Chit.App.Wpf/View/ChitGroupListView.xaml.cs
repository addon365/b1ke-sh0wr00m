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
    public partial class ChitGroupListView : Window
    {
        public ChitGroupListView()
        {
            InitializeComponent();
            DialogOption.Visibility = Visibility.Hidden;
        }
        public ChitGroupListView(bool dialogMode)
        {
            InitializeComponent();
            if (dialogMode == true)
            {
                DialogOption.Visibility = Visibility.Visible;
            }
            else
            {
                DialogOption.Visibility = Visibility.Hidden;
            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var vm = this.DataContext as ChitGroupListViewModel;
                if (vm.SelectedChitGroup == null)
                    throw new Exception("Group not selected");

                ChitGroupView chitGroupView = new ChitGroupView(vm.SelectedChitGroup.KeyId);

                chitGroupView.ShowDialog();
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
            this.dgGroupList.SearchHelper.AllowFiltering = true;
            this.dgGroupList.SearchHelper.Search(txtSearchText.Text);
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            this.dgGroupList.SearchHelper.ClearSearch();
        }
    }
}
