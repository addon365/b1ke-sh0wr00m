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
    /// Interaction logic for NewSchemaWindow.xaml
    /// </summary>
    public partial class NewSchemaWindow : Window
    {
        SchemeViewModel viewmodel;
        public NewSchemaWindow()
        {
            InitializeComponent();
            viewmodel = new SchemeViewModel();
            base.DataContext = viewmodel;
        }
    }
}
