using System.Windows;
using addon365.UI.ViewModel;

namespace addon365.UI.WPF.Enquiries
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
            vm.msg = new CustomMessageBox();
            this.DataContext = vm;

        }
       
    }
   
}
