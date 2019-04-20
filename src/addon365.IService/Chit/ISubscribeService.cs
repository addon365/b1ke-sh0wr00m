using addon365.Database.Entity.Chit;
using addon365.Database.Entity.Crm;
using addon365.Domain.Entity.Chit.Reports;
using addon365.IService.Base;
using System;
using System.Collections.Generic;

namespace addon365.IService.Chit
{
    public interface ISubscribeService:IBaseService<ChitSubscriber>
    {
        ChitSubscriber FindBySubscriptionId(string id);
        string CloseSubscription(string id, double amount);
        IList<SubscriberReportDomain> FetchReport(Guid schemeId, Guid customerId);
        IList<Customer> FindAllCustomers();
    }
}
