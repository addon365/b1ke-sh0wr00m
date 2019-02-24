using System;
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
using ViewModel.Chit;

namespace BikeShowRoom.WPF.Chit
{
    /// <summary>
    /// Interaction logic for NewSubscriberWindow.xaml
    /// </summary>
    public partial class NewSubscriberWindow : Window
    {
        private readonly SubscribeViewModel viewmodel;

        public NewSubscriberWindow()
        {
            InitializeComponent();
            viewmodel = new SubscribeViewModel();
            base.DataContext = viewmodel;
        }
    }
}
