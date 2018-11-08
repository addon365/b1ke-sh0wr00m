using Api.Database.Entity.Crm;
using Api.Database.Entity.Enquiries;
using Api.Domain.Enquiries;
using CrystalDecisions.CrystalReports.Engine;
using Swc.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ViewModel
{
    public class EnquiriesListViewModel : ViewModelBase
    {
        private readonly IEnquiriesService _repository;
        private IEnumerable<Enquiries> _enquiries;
        public EnquiriesListViewModel()
        {
            _repository = new addon.BikeShowRoomService.WebService.EnquiriesService();

            _enquiries = _repository.GetAllActive();
            WireCommands();
            PrintCommand.IsEnabled = true;
        }
        #region Commands
        private void WireCommands()
        {
            PrintCommand = new RelayCommand(PrintEnquiry);
        }
        public RelayCommand PrintCommand
        {
            get;
            private set;
        }
        
        #endregion

        public IEnumerable<Enquiries> Enquiries
        {
            get
            {
        
                return _enquiries;
            }

            set
            {
                if (_enquiries != value)
                {
                    _enquiries = value;
                    OnPropertyChanged("Enquiries");

                }
            }
        }
        public ICrystalReport ReportObj { get; set; }

        public void PrintEnquiry()
        {
            if (ReportObj == null)
                return;

            ReportDocument rd = new ReportDocument();
            string assemblyFile = (
    new System.Uri(Assembly.GetExecutingAssembly().CodeBase)
).AbsolutePath;
            string path = Path.GetDirectoryName(assemblyFile);
            rd.Load(path+@"\..\..\reports\reports\ContactList.rpt");
            DataTable dt = new DataTable();
            dt.TableName = "Contact";
            dt.Columns.Add("Name");
            dt.Columns.Add("MobileNumber");
            foreach (Enquiries cr in Enquiries)
            {
                DataRow dr = dt.NewRow();
                dr["Name"] = cr.Contact.Name;
                dr["MobileNumber"] = cr.Contact.MobileNumber;
                dt.Rows.Add(dr);
            }
            rd.SetDataSource(dt);
               
            ReportObj.ShowReport(rd);
        }
    }
}
