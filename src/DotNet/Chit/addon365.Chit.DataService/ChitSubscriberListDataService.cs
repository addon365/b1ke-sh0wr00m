using addon365.Chit.DataEntity;
using addon365.Chit.DomainEntity;
using addon365.Chit.EfContext;
using addon365.Chit.IDataService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Threenine.Data;


namespace addon365.Chit.DataService
{
    public class ChitSubscriberListDataService: IChitSubscriberListDataService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ChitSubscriberListDataService(IUnitOfWork<DatabaseContext> unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public void Delete(Guid KeyId)
        {
            throw new NotImplementedException();
        }

        public void Edit(Guid KeyId)
        {
            throw new NotImplementedException();
        }

        public IList<ChitSubscriberModel> GetAll()
        {
            IList<ChitSubscriberModel> lst = new List<ChitSubscriberModel>();
            var data = _unitOfWork.GetRepository<ChitSubscriberTable>().GetList(include:x=>x.Include(x=>x.Customer).ThenInclude(x=>x.Contact));
            foreach (ChitSubscriberTable chitSubscriber in data.Items)
            {
                lst.Add(new ChitSubscriberModel { FirstName = chitSubscriber.Customer.Contact.FirstName });
            }

            return lst;
        }
    }
}
