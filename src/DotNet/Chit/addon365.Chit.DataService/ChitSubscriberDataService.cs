using addon365.Chit.DataEntity;
using addon365.Chit.DomainEntity;
using addon365.Chit.EfContext;
using addon365.Chit.IDataService;
using addon365.Crm.DataEntity;
using System;
using System.Collections.Generic;
using Threenine.Data;

namespace addon365.Chit.DataService
{
    public class ChitSubscriberDataService : IChitSubscriberDataService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ChitSubscriberDataService(IUnitOfWork<DatabaseContext> unitOfWork)
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
            _unitOfWork.GetRepository<ChitSchemeTable>().Add(new ChitSchemeTable { KeyId = Guid.NewGuid() });

            _unitOfWork.SaveChanges();
            //var products = _unitOfWork.GetRepository<ChitSchemeModel>().GetList();
        }

        public ChitSubscriberMasterModel GetMasterData()
        {
            IList<ChitGroupModel> lst = new List<ChitGroupModel>();
            foreach (ChitGroupTable chitGroupTable in _unitOfWork.GetRepository<ChitGroupTable>().GetList().Items)
            {
                lst.Add(new ChitGroupModel {KeyId=chitGroupTable.KeyId, GroupName = chitGroupTable.GroupName, Amount = chitGroupTable.Amount });
            }

            ChitSubscriberMasterModel m = new ChitSubscriberMasterModel();
            m.ChitGroupList = lst;

            return m;
        }

        public void Insert(ChitSubscriberModel chitSubscriberModel)
        {
            var contactModel = new ContactTable { KeyId = Guid.NewGuid(), FirstName = chitSubscriberModel.FirstName, LastName = chitSubscriberModel.LastName, Place = chitSubscriberModel.Place, MobileNumber = chitSubscriberModel.MobileNo };
            var customerModel = new CustomerTable { KeyId = Guid.NewGuid(),ContactKeyId=contactModel.KeyId};
            _unitOfWork.GetRepository<ContactTable>().Add(contactModel);
            _unitOfWork.GetRepository<CustomerTable>().Add(customerModel);
            _unitOfWork.GetRepository<ChitSubscriberTable>().Add(new ChitSubscriberTable { KeyId = Guid.NewGuid(),CustomerKeyId=customerModel.KeyId,ChitGroupKeyId=chitSubscriberModel.ChitGroupKeyId });
            _unitOfWork.SaveChanges();
        }
        

        public void Update(ChitSubscriberModel chitSubscriberModel)
        {
            throw new NotImplementedException();
        }
    }
}
