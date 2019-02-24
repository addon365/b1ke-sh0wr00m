using addon365.Database.Entity.Chit;
using System;
using System.Collections.Generic;
using System.Linq;
namespace addon365.Domain.Entity.Chit
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
                var dueDomain = new ChitDueDomain
                {
                    DueNo = dueItem.DueNo,
                    Date = dueItem.Voucher.VoucherDate,

                };
               
                if (dueItem.Voucher.VoucherInfos.Count > 0)
                {
                    dueDomain.Amount = dueItem.Voucher.VoucherInfos.ToArray()[0].Amount;
                }
                chitDueDomains.Add(dueDomain);
            }
            return chitDueDomains;
        }
    }
}
