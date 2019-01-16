using Api.Database.Entity.Chit;
using Api.Domain.Chit;
using Swc.Service.Base;
using System;
using System.Collections.Generic;

namespace Swc.Service.Chit
{
    public interface IChitDueService : IBaseService<ChitSubriberDue>
    {
        List<ChitSubriberDue> GetList(Guid chitSubriberId);
        ChitSubriberDue Save(ChitSubscribeDomain domain);

    }
}
