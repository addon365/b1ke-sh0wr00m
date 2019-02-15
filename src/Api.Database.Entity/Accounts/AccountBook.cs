using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Database.Entity.Accounts
{
    public class AccountBook:BaseEntityWithLogFields
    {
        public string Identifier { get; set; }
        public string BookName { get; set; }
        public Guid UnderGroupId { get; set; }
        public string ProgrammerId { get; set; }


    }
    public enum AccountBookEnum { Cash, Booking, Purchase, PurchaseBalance,GstBook }
}
