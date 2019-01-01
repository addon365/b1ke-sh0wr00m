using Api.Database.Entity.Chit;
using System;
using System.Collections.Generic;

namespace Api.Domain.Chit
{
    public class ChitDueDomain
    {
        public string DueNo { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public static  List<ChitDueDomain> FromEntityModels(
            List<ChitSubriberDue> items)
        {
            List<ChitDueDomain> chitDueDomains =
                new List<ChitDueDomain>(items.Count);
            foreach(ChitSubriberDue dueItem in items)
            {
                chitDueDomains.Add(new ChitDueDomain
                {
                    DueNo = dueItem.DueNo,
                    Date = dueItem.VoucherInfo.Voucher.VoucherDate,
                    Amount = dueItem.VoucherInfo.Amount
                });
            }
            return chitDueDomains;
        }
    }
}
