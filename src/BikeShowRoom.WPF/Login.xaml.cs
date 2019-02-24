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
using System.Windows.Navigation;
using System.Windows.Shapes;
using addon365.UI.ViewModel;

namespace addon365.UI.WPF
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            LoginViewModel lmv= new LoginViewModel();
            lmv.LoginSuccess = new LoginSuccess(this);
            lmv.LoginFailed = new LoginFailed();
            lmv.msgBox = new MessageB();
            
            this.DataContext = lmv;
            
            

        }

        private void CrossButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
    public class LoginSuccess:IViewUI
    {
        Login parent;
        public LoginSuccess(Login parent)
        {
            this.parent = parent;
        }

        public void ShowUI()
        {
            ContactWindow win = new ContactWindow();
            win.Show();
            parent.Close();
        }
    }
    public class LoginFailed : IViewUI
    {
     

        public void ShowUI()
        {
            MessageBox.Show("Incorrect Information");
        }
    }
    public class MessageB : IMsgBox
    {


        public void ShowUI(string msg)
        {
            MessageBox.Show(msg);
        }
    }


}
