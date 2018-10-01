using Api.Database.Entity;
using Api.Database.Entity.Enquiries;
using Api.Database.Entity.Products;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ViewModel;

namespace BikeShowRoom.WPF
{
    /// <summary>
    /// Interaction logic for Enquiries.xaml
    /// </summary>
    public partial class EnquiryWindow : Window
    {
        List<Enquiry> enquiries;
        List<Profile> profiles;
        List<EnquiryProduct> enquiryProducts;
       
        public EnquiryWindow()
        {
            InitializeComponent();
            var vm= new EnquiryViewModel();
            vm.CurrentEnquiry = new Api.Domain.Enquiries.Enquiries();
            this.DataContext = vm;
            enquiries = new List<Enquiry>();
            profiles = new List<Profile>();
            enquiryProducts = new List<EnquiryProduct>();
            

          
            
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            var products=cmbVehicle.ItemsSource as IEnumerable<Product>;
            //Enquiry enquiry = new Enquiry();
            //enquiry.Id=Guid.NewGuid();

            //Profile profile = new Profile();
            //profile.Id = Guid.NewGuid();
            //profile.Name = txtName.Text;
            //profile.MobileNumber = txtMobileNo.Text;
            //profile.Address = txtAddress.Text;
            //enquiry.ProfileId = profile.Id;

            //Product product = cmbVehicle.SelectedItem as Product;
            //EnquiryProduct enquiryProduct = null;
            //if (product!=null)
            //{
            //    enquiryProduct = new EnquiryProduct();
            //    enquiryProduct.Id = Guid.NewGuid();
            //    enquiryProduct.EnquiryId = enquiry.Id;
            //    enquiryProduct.ProductId = product.Id;
                
            //}

            //enquiries.Add(enquiry);
            //profiles.Add(profile);
            //foreach (EnquiryProduct ep in enquiryProducts)
            //{
            //    if(ep.EnquiryId==null)
            //        ep.EnquiryId = enquiry.Id;
            //}
            //if (enquiryProduct!=null)
            //enquiryProducts.Add(enquiryProduct);


            

        }

        private void btnAddAnotherVechicle_Click(object sender, RoutedEventArgs e)
        {
            Product product = cmbVehicle.SelectedItem as Product;
            
            if (product != null)
            {
                
                var enquiryProduct = new EnquiryProduct();
                enquiryProduct.Id = Guid.NewGuid();
                enquiryProduct.ProductId = product.Id;
                enquiryProduct.product = product;
                enquiryProduct.OnRoadPrice = product.Price;
                enquiryProduct.AccessoriesAmount = AccessoriesAmount;
                enquiryProduct.TotalAmount = product.Price + AccessoriesAmount;
                enquiryProducts.Add(enquiryProduct);
            }
            dgVechicleEnquired.ItemsSource = null;
            dgVechicleEnquired.ItemsSource = enquiryProducts;
            
            ClearVechicleDetail();


        }
        void ClearVechicleDetail()
        {
            cmbVehicle.SelectedItem = null;
            ClearAccessoriesStatus();
            txtVechicleOnRoad.Text = "";
            txtAmount.Text = "";
        }
        void ClearAccessoriesStatus()
        {
            chkBoxFibre.IsChecked = false;
            chkBuzzer.IsChecked = false;
            chkFloorMat.IsChecked = false;
            chkGripCover.IsChecked = false;
            chkNumberPlate.IsChecked = false;
            chkRearViewMirror.IsChecked = false;
            chkSareeGuard.IsChecked = false;
        }
        private void cmbVehicle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                txtVechicleOnRoad.Text = "";
            if(cmbVehicle!=null)
            {
                if(cmbVehicle.SelectedItem!=null)
                {
                    ClearAccessoriesStatus();
                    Product product = cmbVehicle.SelectedItem as Product;
                    txtVechicleOnRoad.Text = "Rs." + product.Price;
                    txtAmount.Text = txtVechicleOnRoad.Text;
                }
            }
                
            }
            catch(Exception ex)
            {
                txtVechicleOnRoad.Text = "ERR";
            }
        }
        double AccessoriesAmount;
        private void chkAccessories_Checked(object sender, RoutedEventArgs e)
        {
            if (cmbVehicle.SelectedItem == null)
            {
                return;
            }
            double OnRoadPrice = (cmbVehicle.SelectedItem as Product).Price;
            AccessoriesAmount = 0;
            if(chkBoxFibre.IsChecked==true)
            {
                AccessoriesAmount = AccessoriesAmount + 150;
            }
            if (chkBuzzer.IsChecked == true)
            {
                AccessoriesAmount = AccessoriesAmount + 100;
            }
            if (chkFloorMat.IsChecked == true)
            {
                AccessoriesAmount = AccessoriesAmount +200;
            }
            if (chkGripCover.IsChecked == true)
            {
                AccessoriesAmount = AccessoriesAmount + 80;
            }
            if (chkNumberPlate.IsChecked == true)
            {
                AccessoriesAmount = AccessoriesAmount + 250;
            }
            if (chkRearViewMirror.IsChecked == true)
            {
                AccessoriesAmount = AccessoriesAmount + 150;
            }
            if (chkSareeGuard.IsChecked == true)
            {
                AccessoriesAmount = AccessoriesAmount + 550;
            }
            txtAmount.Text = "Rs." + (OnRoadPrice + AccessoriesAmount);
        }

        private void VechicleGridDelete_Click(object sender, RoutedEventArgs e)
        {

            enquiryProducts.Remove(dgVechicleEnquired.SelectedItem as EnquiryProduct);
            dgVechicleEnquired.ItemsSource = null;
            dgVechicleEnquired.ItemsSource = enquiryProducts;
        }
    }
}
