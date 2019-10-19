using addon365.Database.Entity.Chit;
using addon365.Domain.Entity.Chit;
using addon365.IService.Base;
using System;
using System.Collections.Generic;

namespace addon365.IService.Chit
{
    public interface IChitDueService : IBaseService<ChitSubriberDue>
    {
        List<ChitSubriberDue> GetList(Guid chitSubriberId);
        ChitSubriberDue Save(ChitSubscribeDomain domain);
        IList<CustomerDueDomain> FindByMobile(string mobileNumber);
        IList<CustomerDueDomain> FindByCustomerName(string customerName);

    }
}
