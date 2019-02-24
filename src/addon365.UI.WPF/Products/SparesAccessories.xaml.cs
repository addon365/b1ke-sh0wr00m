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
using addon365.UI.ViewModel;

namespace addon365.UI.WPF.Products
{
    /// <summary>
    /// Interaction logic for ProductInsertWindow.xaml
    /// </summary>
    public partial class SparesAccessories : Window
    {
        ProductViewModel ViewModel;
        public SparesAccessories()
        {
            try { 
            InitializeComponent();
            ViewModel = new ProductViewModel();
            ViewModel.InsertCommand.IsEnabled = true;
            base.DataContext =ViewModel;
            }
            catch(Exception ex)
            {
                if(ex.InnerException==null)
                { 
                MessageBox.Show("Error 1" + ex.Message);
                }
                else
                {
                    MessageBox.Show("Error 2" + ex.InnerException.Message);

                    if(ex.InnerException.InnerException!=null)
                    {
                        MessageBox.Show("Error 3" + ex.InnerException.InnerException.Message);
                    }
                }
            }
        }

        

      
    }
}
