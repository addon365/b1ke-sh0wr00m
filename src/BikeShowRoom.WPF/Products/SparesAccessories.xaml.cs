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
using ViewModel;

namespace BikeShowRoom.WPF.Products
{
    /// <summary>
    /// Interaction logic for ProductInsertWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        ProductViewModel viewmodel;
        public ProductWindow()
        {
            try { 
            InitializeComponent();
            viewmodel = new ProductViewModel();
            viewmodel.InsertCommand.IsEnabled = true;
            base.DataContext = viewmodel;
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
