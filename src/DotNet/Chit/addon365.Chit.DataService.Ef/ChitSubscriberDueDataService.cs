using addon365.Accounting.DataEntity;
using addon365.Chit.Database.EfContext;
using addon365.Chit.DataEntity;
using addon365.Chit.DomainEntity;
using addon365.Common.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Threenine.Data;

namespace addon365.Chit.DataService.Ef
{

    public class ChitSubscriberDueDataService : IChitSubscriberDueDataService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IChitSubscriberDueListDataService _dueListService;
        private IChitSubscriberDataService _chitSubscriberDataService;
        public ChitSubscriberDueDataService(IUnitOfWork<DatabaseContext> unitOfWork, IChitSubscriberDueListDataService dueListService, IChitSubscriberDataService chitSubscriberDataService)
        {
            this._unitOfWork = unitOfWork;
            this._dueListService = dueListService;
            this._chitSubscriberDataService = chitSubscriberDataService;
        }
        public void Delete(Guid KeyId)
        {
            throw new NotImplementedException();
        }

        public ChitSubscriberDueModel Get(Guid KeyId)
        {
            throw new NotImplementedException();
        }
        public ChitSubscriberDueModel Get(string AccessId)
        {
            var data = _unitOfWork.GetRepository<ChitSubscriberDueTable>().Single(x => x.AccessId == AccessId, include:x=>x.Include(x=>x.DueAmountInfo).ThenInclude(x=>x.Voucher).Include(x => x.ChitSubscriber).ThenInclude(x => x.Customer).ThenInclude(x => x.Contact).Include(x=>x.ChitSubscriber).ThenInclude(x=>x.Agent).ThenInclude(x=>x.Contact).Include(x=>x.ChitSubscriber).ThenInclude(x=>x.ChitGroup));
            ChitSubscriberDueModel chit = new ChitSubscriberDueModel
            {
                AccessId = data.AccessId,
                ChitSubscriber = new ChitSubscriberModel
                {
                    AccessId = data.ChitSubscriber.AccessId,
                    Customer = new CustomerModel
                    {
                        AccessId = data.ChitSubscriber.Customer.AccessId,
                        ContactKeyId = data.ChitSubscriber.Customer.Contact.KeyId,
                        FirstName = data.ChitSubscriber.Customer.Contact.FirstName,
                        LastName = data.ChitSubscriber.Customer.Contact.LastName,
                        MobileNo = data.ChitSubscriber.Customer.Contact.MobileNumber

                    },
                    Agent = new AgentModel { AccessId = data.ChitSubscriber.Agent.AccessId },
                    ChitGroup = new ChitGroupModel { AccessId = data.ChitSubscriber.ChitGroup.AccessId }



                },
                Amount = data.DueAmountInfo.Amount,
                TransactionDate = data.DueAmountInfo.Voucher.VoucherDate


            };
            return chit;
           
        }
        public ChitDueSubscriberDetailModel GetSubscriberDetail(string accessId)
        {
            ChitDueSubscriberDetailModel model = new ChitDueSubscriberDetailModel();
            var dataSubscriber = _chitSubscriberDataService.Get(accessId);
            model.Subscriber = dataSubscriber;
            model.DueDetail = _dueListService.Get(dataSubscriber.KeyId);
        
            return model;
        }

        public void GetAll()
        {
           
        }

        public ChitSubscriberDueScreenModel GetMasterData()
        {
           
           

            ChitSubscriberDueScreenModel m = new ChitSubscriberDueScreenModel();
  

         

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
