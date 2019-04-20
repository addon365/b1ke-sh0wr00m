using addon365.Database.Entity.Enquiries;
using addon365.Database.Entity.Report;
using System;
using System.Collections.Generic;
using System.Linq;

namespace addon365.IService.Report
{
    /// <summary>
    /// Service to serve Inquiry reports in different formats.
    /// </summary>
    public interface IInquiryReportService
    {
        IEnumerable<InquiryReport> GetReport(ReportType type);

    }
}
