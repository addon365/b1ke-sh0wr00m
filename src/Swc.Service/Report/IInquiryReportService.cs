using Api.Database.Entity.Enquiries;
using Api.Database.Entity.Report;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Swc.Service.Report
{
    /// <summary>
    /// Service to serve Inquiry reports in different formats.
    /// </summary>
    public interface IInquiryReportService
    {
        IEnumerable<InquiryReport> GetReport(ReportType type);

    }
}
