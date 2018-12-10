using System;
using System.Collections.Generic;
using System.Text;

namespace Swc.Service.Report
{
    public enum ReportType
    {
        MONTH,
        YEAR,
        NAME
    }
    public static class ReportQueries
    {
        public static string COUNT_BY_NAME = 
            @"SELECT ROW_NUMBER() OVER(ORDER BY (SELECT 1)) AS Id,
                GetDate() date, 
                ir.Name,SUM(ir.Count) Count FROM swc.InquiryReport ir 
                GROUP BY ir.Name;";
        public static string COUNT_BY_YEAR = 
            @"SELECT ROW_NUMBER() OVER(ORDER BY (SELECT 1)) AS Id,
                datefromparts(YEAR(ir.Date),1,1) Date,
                ir.Name,SUM(ir.Count) Count FROM swc.InquiryReport ir 
                GROUP By YEAR(ir.Date), ir.Name;";

    }
}
