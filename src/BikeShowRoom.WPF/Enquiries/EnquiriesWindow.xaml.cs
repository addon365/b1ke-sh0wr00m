using System.Windows;
using ViewModel;

namespace BikeShowRoom.WPF.Enquiries
{
    /// <summary>
    /// Interaction logic for Enquiries.xaml
    /// </summary>
    public partial class EnquiryWindow : Window
    {
        public EnquiryWindow()
        {
            InitializeComponent();
            var vm= new EnquiryViewModel();
            this.DataContext = vm;
        }
    }
}
