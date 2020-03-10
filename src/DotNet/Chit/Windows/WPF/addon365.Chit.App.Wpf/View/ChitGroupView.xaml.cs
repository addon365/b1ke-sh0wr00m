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
    /// Interaction logic for ChitGroupView.xaml
    /// </summary>
    public partial class ChitGroupView : Window
    {
        public ChitGroupView()
        {
            InitializeComponent();
            
        }
        public ChitGroupView(Guid keyId)
        {
            InitializeComponent();
            var vm = this.DataContext as ChitGroupViewModel;
            vm.LoadGroup(keyId);

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtGroupId.Focus();
        }
    }
}
