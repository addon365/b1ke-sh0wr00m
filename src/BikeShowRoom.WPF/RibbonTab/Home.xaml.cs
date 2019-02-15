#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using BikeShowRoom.WPF.CRM.Contact;
using Syncfusion.Windows.Tools.Controls;
using System.Windows;
using Unity;

namespace BikeShowRoom.WPF
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : RibbonTab
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btnEnquiry_Click(object sender, RoutedEventArgs e)
        {
            Enquiries.EnquiryWindow n = new Enquiries.EnquiryWindow();
          
            n.ShowDialog();
        }

        private void btnProduct_Click(object sender, RoutedEventArgs e)
        {
            Products.ProductWindow n = new Products.ProductWindow();
        
            n.ShowDialog();
        }

        private void btnProductCompany_Click(object sender, RoutedEventArgs e)
        {
            Products.ProductCompanyWindow n = new Products.ProductCompanyWindow();

            n.ShowDialog();
        }

        private void btnEnquiryType_Click(object sender, RoutedEventArgs e)
        {
            Enquiries.EnquiriesTypeWindow n = new Enquiries.EnquiriesTypeWindow();
            n.ShowDialog();

        }

        private void btnProductList_Click(object sender, RoutedEventArgs e)
        {
            Products.ProductListWindow n = new Products.ProductListWindow();
            n.ShowDialog();
        }

        private void btnBikeAccessories_Click(object sender, RoutedEventArgs e)
        {
            Products.VehicleAccessories n = new Products.VehicleAccessories();
            n.ShowDialog();
        }

        private void btnEnquiryTypeList_Click(object sender, RoutedEventArgs e)
        {
            Enquiries.EnquriesTypeListWindow n = new Enquiries.EnquriesTypeListWindow();
            n.ShowDialog();
        }

        private void btnProductCompanyList_Click(object sender, RoutedEventArgs e)
        {
            Products.ProductCompanyListWindow n = new Products.ProductCompanyListWindow();
            n.ShowDialog();
        }


        private void btnEnquiryList_Click(object sender, RoutedEventArgs e)
        {
            Enquiries.EnquriesListWindow n = new Enquiries.EnquriesListWindow();
            n.ShowDialog();
        }
        private void btnZonal_Click(object sender, RoutedEventArgs e)
        {
            Zonal.ZonalWindow n = new Zonal.ZonalWindow();
            n.ShowDialog();
        }

        private void btnZonalList_Click(object sender, RoutedEventArgs e)
        {
            Zonal.ZonalListWindow n = new Zonal.ZonalListWindow();

            n.ShowDialog();
        }

        

        private void btnSales_Click(object sender, RoutedEventArgs e)
        {
            Sales.VechicleSale n = new Sales.VechicleSale();
            n.ShowDialog();
        }
        private void rbnContactList_Click(object sender, RoutedEventArgs e)
        {
            ContactListWindow contactListWindow = new ContactListWindow(); ;
            contactListWindow.ShowDialog();
        }

        private void BtnBookingList_Click(object sender, RoutedEventArgs e)
        {
            Enquiries.BookingListWindow n = new Enquiries.BookingListWindow();
            n.ShowDialog();
        }

        private void BtnPurchase_Click(object sender, RoutedEventArgs e)
        {
            Inventory.Purchase n = new Inventory.Purchase();
            n.ShowDialog();
        }

        private void BtnSeller_Click(object sender, RoutedEventArgs e)
        {
            Inventory.SellerWindow n = new Inventory.SellerWindow();
            n.ShowDialog();
        }

        private void BtnSellerList_Click(object sender, RoutedEventArgs e)
        {
            Inventory.SellerListWindow n = new Inventory.SellerListWindow();
            n.ShowDialog();
        }

        private void BtnPurchaseList_Click(object sender, RoutedEventArgs e)
        {
     
            Inventory.PurchaseList n = ServiceCollections.Instance.container.Resolve<Inventory.PurchaseList>();
            n.ShowDialog();
        }
    }
}
