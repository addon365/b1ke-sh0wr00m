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
    public class ChitSubscriberDueListDataService : IChitSubscriberDueListDataService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ChitSubscriberDueListDataService(IUnitOfWork<DatabaseContext> unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public void Delete(Guid KeyId)
        {

            _unitOfWork.GetRepository<ChitSubscriberTable>().Delete(_unitOfWork.GetRepository<ChitSubscriberTable>().Single(x => x.KeyId == KeyId));
        }

        public void Edit(Guid KeyId)
        {
            throw new NotImplementedException();
        }

        public IList<ChitSubscriberDueListModel> GetAll()
        {
            IList<ChitSubscriberDueListModel> lst = new List<ChitSubscriberDueListModel>();
            var data = _unitOfWork.GetRepository<ChitSubscriberDueTable>().GetList(orderBy: x => x.OrderBy(x => Convert.ToInt32(x.AccessId)),include: x => x.Include(x => x.ChitSubscriber).ThenInclude(x => x.Customer).ThenInclude(x => x.Contact).Include(x=>x.DueAmountInfo).Include(x=>x.ChitSubscriber.ChitGroup).Include(x=>x.DueAmountInfo.Voucher),index:0,size:5000);
            foreach (ChitSubscriberDueTable chitSubscriberDue in data.Items)
            {
                var Contact = chitSubscriberDue.ChitSubscriber.Customer.Contact;
                lst.Add(new ChitSubscriberDueListModel { FirstName = Contact.FirstName, LastName = Contact.LastName, Place = Contact.Place, MobileNo = Contact.MobileNumber, AccessId = chitSubscriberDue.AccessId, KeyId = chitSubscriberDue.KeyId,Amount=chitSubscriberDue.DueAmountInfo.Amount,GroupName=chitSubscriberDue.ChitSubscriber.ChitGroup.GroupName,TransactionDate=chitSubscriberDue.DueAmountInfo.Voucher.VoucherDate });
            }

            return lst;
        }
    }
}
