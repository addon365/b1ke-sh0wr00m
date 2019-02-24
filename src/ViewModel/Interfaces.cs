using CrystalDecisions.CrystalReports.Engine;

namespace addon365.UI.ViewModel
{
    public interface IViewUI
    {
        void ShowUI();
        
    }
    public interface IViewUI<T>
    {
        void ShowUI(T Model);

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