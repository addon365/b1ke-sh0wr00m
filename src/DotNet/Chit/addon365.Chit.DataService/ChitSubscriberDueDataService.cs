using addon365.Accounts.DataEntity;
using addon365.Chit.DataEntity;
using addon365.Chit.DomainEntity;
using addon365.Chit.EfContext;
using addon365.Chit.DataHelper;
using addon365.Common.Helper;
using addon365.Crm.DataEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Threenine.Data;

namespace addon365.Chit.EfDataService
{
    public class ChitSubscriberDueDataService : IChitSubscriberDueDataService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ChitSubscriberDueDataService(IUnitOfWork<DatabaseContext> unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public void Delete(Guid KeyId)
        {
            throw new NotImplementedException();
        }

        public void Get(Guid KeyId)
        {
            throw new NotImplementedException();
        }

        public void GetAll()
        {
           
        }

        public ChitSubscriberDueScreenModel GetMasterData()
        {
           
           

            ChitSubscriberDueScreenModel m = new ChitSubscriberDueScreenModel();
  

            IList<ChitSubscriberModel> lstSub = new List<ChitSubscriberModel>();
            var data = _unitOfWork.GetRepository<ChitSubscriberTable>().GetList(include: x => x.Include(x => x.Customer).ThenInclude(x => x.Contact).Include(x => x.ChitGroup),index:0,size:5000);
            foreach (ChitSubscriberTable chitSubscriber in data.Items)
            {
                var Contact = chitSubscriber.Customer.Contact;
                lstSub.Add(new ChitSubscriberModel { Customer=new CustomerModel { FirstName = Contact.FirstName, LastName = Contact.LastName, Place = Contact.Place, MobileNo = Contact.MobileNumber }, AccessId = chitSubscriber.AccessId, KeyId = chitSubscriber.KeyId,ChitDueAmount=chitSubscriber.ChitGroup.ChitDueAmount, ChitGroup=new ChitGroupModel { KeyId = chitSubscriber.ChitGroup.KeyId, GroupName = chitSubscriber.ChitGroup.GroupName, } });
            }
            m.ChitSubscriberList = lstSub;

            var Max = _unitOfWork.GetRepository<ChitSubscriberDueTable>().Single(orderBy: x => x.OrderByDescending(m => Convert.ToInt64(m.AccessId)));

            if (Max != null)
                m.MaxAccessId = Max.AccessId;
            else
                m.MaxAccessId = "0";
            return m;
        }

        public void Insert(ChitSubscriberDueModel chitSubscriberDueModel)
        {
            var voucherModel = new VoucherTable { KeyId = Guid.NewGuid(), VoucherDate = System.DateTime.Now };
            _unitOfWork.GetRepository<VoucherTable>().Add(voucherModel);
            string st = Reflection.GetPropFullName(new ChitSubscriberDueTable(), "DueAmountInfoKeyId");

            
            if (st != "")
            {
                AccountBookFieldMapTable row = _unitOfWork.GetRepository<AccountBookFieldMapTable>().Single(x => x.FieldNameKey == st);
                var CashBook = _unitOfWork.GetRepository<AccountBookTable>().Single(x => x.ProgId == AccountBookProgs.CashBook);
                if (row != null && CashBook!=null)
                {
                    string AccessId = int.Parse(chitSubscriberDueModel.AccessId).ToString();

                    var voucherInfoModelCr = new VoucherInfoTable { KeyId = Guid.NewGuid(), VoucherKeyId = voucherModel.KeyId, AccountBookKeyId = row.AccountBookKeyId, Amount = chitSubscriberDueModel.Amount, IsCredit = true };
                    var voucherInfoModelDr = new VoucherInfoTable { KeyId = Guid.NewGuid(), VoucherKeyId = voucherModel.KeyId, AccountBookKeyId = CashBook.KeyId, Amount = chitSubscriberDueModel.Amount, IsCredit = false };
                    _unitOfWork.GetRepository<VoucherInfoTable>().Add(voucherInfoModelCr);
                    _unitOfWork.GetRepository<VoucherInfoTable>().Add(voucherInfoModelDr);
                    _unitOfWork.GetRepository<ChitSubscriberDueTable>().Add(new ChitSubscriberDueTable { KeyId = Guid.NewGuid(),AccessId=chitSubscriberDueModel.AccessId, ChitSubscriberKeyId = chitSubscriberDueModel.ChitSubscriberKeyId, DueAmountInfoKeyId = voucherInfoModelCr.KeyId });
                    _unitOfWork.SaveChanges();
                }
            }
            else
            {
                throw new Exception("Account Book not Configured");
            }
        }
      

        public void Update(ChitSubscriberDueModel chitSubscriberModel)
        {
            throw new NotImplementedException();
        }
    }
}
