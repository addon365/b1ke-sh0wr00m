using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Database.Entity.Report
{
    public class InquiredMonthly
    {
        [Key]
        public Int64 Id { get; set; }
        public int MonthIndex { get; set; }
        public string ProductName { get; set; }
        public int ProductCount { get; set; }
    }
}
