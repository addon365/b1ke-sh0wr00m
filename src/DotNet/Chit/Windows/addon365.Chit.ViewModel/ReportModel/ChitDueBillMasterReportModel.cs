using System;
using System.Collections.Generic;
using System.Text;

namespace addon365.Chit.ViewModel.ReportModel
{
    public class ChitDueBillMasterReportModel
    {
        public String KeyId { get; set; }
        public String BillNo { get; set;}
        public DateTime BillDate { get; set; }
        public String CustomerAccessId { get; set; }
        
        public String CustomerName { get; set; }
    }
}
