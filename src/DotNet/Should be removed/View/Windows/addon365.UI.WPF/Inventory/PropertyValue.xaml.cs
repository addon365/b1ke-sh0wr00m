using addon365.Database.Entity.Inventory.Purchases;
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
using addon365.UI.ViewModel.Inventory;

namespace addon365.UI.WPF.Inventory
{
    /// <summary>
    /// Interaction logic for PropertyValue.xaml
    /// </summary>
    public partial class PropertyValue : Window
    {
        private PropertyValueViewModel Model;
        public PropertyValue(PropertyValueViewModel Model)
        {
            InitializeComponent();
            this.Model = Model;
            this.DataContext = Model;

            foreach (PurchaseItemPropertyValue pipv in Model.lstPropertyValues)
            {
                RowDefinition rd = new RowDefinition();
                rd.Height =new GridLength(30);
                ParentGrid.RowDefinitions.Add(rd);

                TextBlock textLabel = new TextBlock();
                textLabel.Text = pipv.CatalogItemPropertyMaster.PropertyName;
                Grid.SetRow(textLabel, ParentGrid.RowDefinitions.Count-1);
                ParentGrid.Children.Add(textLabel);

                TextBox text = new TextBox();
                text.BorderBrush = Brushes.Gray;
                text.Height = 24;
                Grid.SetRow(text, ParentGrid.RowDefinitions.Count - 1);
                Grid.SetColumn(text, 1);
                Binding myBinding = new Binding();
                myBinding.Source = pipv;
                myBinding.Path = new PropertyPath("Value");
                myBinding.Mode = BindingMode.TwoWay;
                myBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                BindingOperations.SetBinding(text, TextBox.TextProperty, myBinding);
                ParentGrid.Children.Add(text);



            }
            


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (PurchaseItemPropertyValue pipv in Model.lstPropertyValues)
            {
                MessageBox.Show(pipv.Value);
            }
        }
    }
}
