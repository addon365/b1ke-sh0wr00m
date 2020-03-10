using addon365.Chit.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace addon365.Chit.App.Wpf.View
{
    /// <summary>
    /// Interaction logic for ucAddSubscriber.xaml
    /// </summary>
    public partial class ChitSubscriberDueView : Window
    {
        public ChitSubscriberDueView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChitSubscriberListView chitSubscriberListView = new ChitSubscriberListView(true);
            chitSubscriberListView.ShowDialog();
            ChitSubscriberListViewModel vm = chitSubscriberListView.DataContext as ChitSubscriberListViewModel;
            if (chitSubscriberListView.DialogResult == true)
            {
                if (vm.SelectedSubscriber != null)
                {
                    ChitSubscriberDueViewModel vm1 = this.DataContext as ChitSubscriberDueViewModel;

                    vm1.SelectedChitSubscriber = vm1.ChitSubscriberList.Where(x => x.KeyId == vm.SelectedSubscriber.KeyId).FirstOrDefault();
                    vm1.SearchSubscriberAccessId = vm1.SelectedChitSubscriber.AccessId;
                }
            }
        }
    }
}
