using CrystalDecisions.CrystalReports.Engine;

namespace ViewModel
{
    public interface IViewUI
    {
        void ShowUI();

    }
    public interface IMsgBox
    {
        void ShowUI(string msg);

    }
    public interface ICrystalReport
    {
        void ShowReport(ReportDocument rep);
    }


}