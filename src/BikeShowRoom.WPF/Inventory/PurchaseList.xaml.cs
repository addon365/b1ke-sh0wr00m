using System.Windows;
using CrystalDecisions.CrystalReports.Engine;
using ViewModel;
using ViewModel.Inventory;

namespace BikeShowRoom.WPF.Inventory
{
    /// <summary>
    /// Interaction logic for ProductListWindow.xaml
    /// </summary>
    public partial class PurchaseList : Window
    {
        //[Dependency]
        //public PurchaseListViewModel viewmodel { set { _ViewModel = value; } }
        PurchaseListViewModel _ViewModel;
        public PurchaseList(PurchaseListViewModel viewmodel)
        {
            InitializeComponent();
            _ViewModel = viewmodel;
            DataContext = viewmodel;
            _ViewModel.Edit = Edit;

        }
      
        public void Edit(Api.Database.Entity.Inventory.Purchases.Purchase identifier)
        {
            PurchaseViewModel ViewModel = new PurchaseViewModel(identifier);
            Purchase en = new Purchase();
            en.DataContext = ViewModel;
            en.ShowDialog();
        }
    }

    public class Reports : ICrystalReport
    {
        public void ShowReport(ReportDocument rep)
        {
            ReportViewer rpt = new ReportViewer(rep);
            rpt.ShowDialog();
            
        }
    }
}
