using CrystalDecisions.CrystalReports.Engine;
using System.Windows;


namespace addon365.UI.WPF
{
    /// <summary>
    /// Interaction logic for ReportViewer.xaml
    /// </summary>
    public partial class ReportViewer : Window
    {
        public ReportViewer(ReportDocument reportdoc)
        {
            InitializeComponent();
            Viewer1.Owner = Window.GetWindow(this);
            Viewer1.ViewerCore.ReportSource = reportdoc;
        }
    }
}
