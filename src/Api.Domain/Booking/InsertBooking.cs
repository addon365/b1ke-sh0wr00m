using Api.Database.Entity.Accounts;
using Api.Domain.Accounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain.Booking
{
    public class InsertBooking
    {
        public Guid EnquiryId { get; set; }
        public DomainVoucherInfo CashAmount { get; set; }
        public Voucher Voucher { get; set; } 
    }
}
