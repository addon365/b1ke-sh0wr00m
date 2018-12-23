using Api.Database.Entity.Chit;
using Swc.Service.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Threenine.Data;

namespace Swc.Service.Chit
{
    public class ChitDueService : BaseService<ChitSubriberDue>,
        IChitDueService
    {
        public ChitDueService(IUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {
        }
    }
}
