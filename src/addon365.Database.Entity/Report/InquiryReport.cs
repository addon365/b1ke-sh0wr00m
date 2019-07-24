using System;
using System.ComponentModel.DataAnnotations;

namespace addon365.Database.Entity.Report
{
    public class InquiryReport
    {
        [Key]
        public Int64 Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
