using addon365.Database.Entity.Report;
using System.Collections.Generic;

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
