using System.Windows;
using CrystalDecisions.CrystalReports.Engine;
using addon365.UI.ViewModel;
using addon365.UI.ViewModel.Inventory;

namespace addon365.UI.WPF.Inventory
{
    /// <summary>
    /// Interaction logic for ProductListWindow.xaml
    /// </summary>
    public partial class PurchaseList : Window
    {
        //[Dependency]
        //public PurchaseListViewModel addon365.UI.ViewModel { set { _ViewModel = value; } }
        PurchaseListViewModel _ViewModel;
        public PurchaseList(PurchaseListViewModel ViewModel)
        {
            InitializeComponent();
            _ViewModel = ViewModel;
            DataContext = ViewModel;
            _ViewModel.Edit = Edit;

        }
      
        public void Edit(addon365.Database.Entity.Inventory.Purchases.Purchase identifier)
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
