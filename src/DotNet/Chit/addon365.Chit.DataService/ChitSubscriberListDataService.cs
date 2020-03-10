using addon365.Chit.DataEntity;
using addon365.Chit.DomainEntity;
using addon365.Chit.EfContext;
using addon365.Chit.DataHelper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Threenine.Data;


namespace addon365.Chit.EfDataService
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

            _unitOfWork.GetRepository<ChitSubscriberTable>().Delete(KeyId);
            _unitOfWork.SaveChanges();

        }

        public void Edit(Guid KeyId)
        {
            throw new NotImplementedException();
        }

        public IList<ChitSubscriberListModel> GetAll()
        {
            IList<ChitSubscriberListModel> lst = new List<ChitSubscriberListModel>();
            var data = _unitOfWork.GetRepository<ChitSubscriberTable>().GetList(orderBy: x => x.OrderBy(x => Convert.ToInt32(x.AccessId)),include:x=>x.Include(x=>x.Customer).ThenInclude(x=>x.Contact).Include(x=>x.ChitGroup).Include(x=>x.Agent).ThenInclude(x=>x.Contact),index:0,size:5000);
            foreach (ChitSubscriberTable chitSubscriber in data.Items)
            {
                var Contact = chitSubscriber.Customer.Contact;
                lst.Add(new ChitSubscriberListModel { FirstName = Contact.FirstName,LastName=Contact.LastName,Place=Contact.Place,MobileNo=Contact.MobileNumber,AccessId=chitSubscriber.AccessId,KeyId=chitSubscriber.KeyId,ChitGroupName=chitSubscriber.ChitGroup.GroupName,Agent=new AgentModel { KeyId = chitSubscriber.Agent.KeyId,FirstName = chitSubscriber.Agent.Contact.FirstName, LastName = chitSubscriber.Agent.Contact.LastName },TotalDue=chitSubscriber.ChitGroup.TotalDues});
            }

            return lst;
        }
    }
}
