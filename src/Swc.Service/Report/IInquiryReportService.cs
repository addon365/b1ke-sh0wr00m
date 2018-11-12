using Api.Database.Entity.Enquiries;
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
        IEnumerable<KeyValuePair<string, int>> GetBasedOnProduct(DateTime fromDate,DateTime toDate);
    }
}
