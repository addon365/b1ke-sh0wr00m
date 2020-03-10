
using System.Windows;
using addon365.Chit.App.Wpf.View;
using addon365.Chit.App.Wpf.ViewModel;
using GalaSoft.MvvmLight.Ioc;

namespace addon365.Chit.App.Wpf
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

        private void btnGroup_Click(object sender, RoutedEventArgs e)
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
            win.Height = 550;
            win.Width = 600;
            win.ShowDialog();
        }

        
        private void btnSubscriberList_Click(object sender, RoutedEventArgs e)
        {
            ChitSubscriberListView win = new ChitSubscriberListView();
            win.Height = 300;
            win.Width = 800;
            win.ShowDialog();
        }

        private void btnDuePayment_Click(object sender, RoutedEventArgs e)
        {
            ChitSubscriberDueView win = new ChitSubscriberDueView();
            win.Height = 400;
            win.Width = 600;
            win.ShowDialog();
        }

        private void btnDueCollectionList_Click(object sender, RoutedEventArgs e)
        {

            ChitSubscriberDueListView win = new ChitSubscriberDueListView();
            win.Height = 300;
            win.Width = 600;
            win.ShowDialog();
        }

        private void btnAgentList_Click(object sender, RoutedEventArgs e)
        {
            AgentListView win = new AgentListView();
            win.Height = 300;
            win.Width = 600;
            win.ShowDialog();
        }

        private void btnAgent_Click(object sender, RoutedEventArgs e)
        {
            AgentView win = new AgentView();
            win.Height = 300;
            win.Width = 600;
            win.ShowDialog();
        }
    }

}
