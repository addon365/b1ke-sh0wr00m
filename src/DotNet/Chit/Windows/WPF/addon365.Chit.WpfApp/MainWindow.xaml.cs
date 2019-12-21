
using System.Windows;
using addon365.Chit.WpfApp.View;
using addon365.Chit.WpfApp.ViewModel;
using GalaSoft.MvvmLight.Ioc;

namespace addon365.Chit.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            //Main.Title = "Test";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChitGroupView win = new ChitGroupView();
            win.Height = 300;
            win.Width = 600;
            win.ShowDialog();
        }

        private void btnGroupList_Click(object sender, RoutedEventArgs e)
        {
            ChitGroupListView win = new ChitGroupListView();
            win.Height = 300;
            win.Width = 600;
            win.ShowDialog();
        }

        private void btnSubscriber_Click(object sender, RoutedEventArgs e)
        {
            ChitSubscriberView win = new ChitSubscriberView();
            win.Height = 300;
            win.Width = 600;
            win.ShowDialog();
        }

        
        private void btnSubscriberList_Click(object sender, RoutedEventArgs e)
        {
            ChitSubscriberListView win = new ChitSubscriberListView();
            win.Height = 300;
            win.Width = 600;
            win.ShowDialog();
        }
    }

}
