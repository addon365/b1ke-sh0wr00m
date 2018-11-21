using System;
using System.Collections.Generic;
using System.Text;

namespace Swc.Service.Report
{
    public static class ReportQueries
    {
        public static string PRODUCTS_BASED_MONTH = "select  ROW_NUMBER() OVER(ORDER BY (SELECT 1)) AS Id,month(en.EnquiryDate) monthIndex,pr.ProductName, count(*) ProductCount from swc.EnquiryProducts ep,swc.Products pr,swc.Enquiries en where ep.ProductId=pr.id and ep.EnquiryId=en.id group by month(en.EnquiryDate),pr.ProductName ORDER BY month(EnquiryDate);";
    }
}
