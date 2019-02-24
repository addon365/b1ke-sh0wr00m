using Api.Database.Entity.Chit;
using Api.Database.Entity.Crm;
using Api.Domain.Chit.Reports;
using Swc.Service.Base;
using System;
using System.Collections.Generic;

namespace Swc.Service.Chit
{
    public interface ISubscribeService:IBaseService<ChitSubscriber>
    {
        ChitSubscriber FindBySubscriptionId(string id);
        string CloseSubscription(string id, double amount);
        IList<SubscriberReportDomain> FetchReport(Guid schemeId, Guid customerId);
        IList<Customer> FindAllCustomers();
    }
}
