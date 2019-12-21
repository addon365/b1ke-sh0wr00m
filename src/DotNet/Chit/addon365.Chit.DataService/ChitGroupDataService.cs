using addon365.Chit.DataEntity;
using addon365.Chit.DomainEntity;
using addon365.Chit.EfContext;
using addon365.Chit.IDataService;
using System;
using System.Collections.Generic;
using System.Text;
using Threenine.Data;

namespace addon365.Chit.DataService
{
    public class ChitGroupDataService : IChitGroupDataService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ChitGroupDataService(IUnitOfWork<DatabaseContext> unitOfWork)
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
            throw new NotImplementedException();
        }

        public ChitGroupMasterModel GetMasterData()
        {
            IList<ChitGroupModel> lst = new List<ChitGroupModel>();
            foreach (ChitGroupTable chitGroupTable in _unitOfWork.GetRepository<ChitGroupTable>().GetList().Items)
            {
                lst.Add(new ChitGroupModel { GroupName = chitGroupTable.GroupName, Amount = chitGroupTable.Amount });
            }

            ChitGroupMasterModel m = new ChitGroupMasterModel();
            m.ChitGroupList = lst;

            return m;
        }

        public void Insert(ChitGroupModel chitGroupModel)
        {
            _unitOfWork.GetRepository<ChitGroupTable>().Add(new ChitGroupTable { KeyId = Guid.NewGuid(), GroupName = chitGroupModel.GroupName, Amount = chitGroupModel.Amount });
            _unitOfWork.SaveChanges();
        }

        public void Update(ChitGroupModel domainModel)
        {
            throw new NotImplementedException();
        }
    }
}
