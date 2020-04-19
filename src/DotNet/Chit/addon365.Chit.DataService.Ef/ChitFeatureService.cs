using addon365.Chit.Database.EfContext;
using addon365.Chit.DomainEntity;
using addon365.Common.DataEntity.Privilage;
using addon365.Common.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Threenine.Data;

namespace addon365.Chit.DataService.Ef
{
    public class ChitFeatureService : IChitFeatureService
    {

        private readonly IUnitOfWork _unitOfWork;
        public ChitFeatureService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public Feature GetFeature()
        {
            var dd=_unitOfWork.GetRepository<BusinessPrivilageTable>().GetList(predicate:x=>x.Source== Reflection.GetFullName(new Feature()));
            
            Feature feature = new Feature();
            feature.Agent = Convert.ToBoolean(dd.Items[0].DefaultValue);
            return feature;
        }
    }
}
