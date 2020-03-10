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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace addon365.Chit.App.Wpf.View
{
    /// <summary>
    /// Interaction logic for ucAddSubscriber.xaml
    /// </summary>
    public partial class ChitSubscriberView : Window
    {
        public ChitSubscriberView(Guid keyId)
        {
            InitializeComponent();
            var vm=this.DataContext as ChitSubscriberViewModel;
            vm.LoadSubscriber(keyId);

        }
        public ChitSubscriberView()
        {
            InitializeComponent();


        }
    }
}
