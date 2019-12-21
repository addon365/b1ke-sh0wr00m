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
    public class ChitGroupListDataService: IChitGroupListDataService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ChitGroupListDataService(IUnitOfWork<DatabaseContext> unitOfWork)
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

        public IList<ChitGroupModel> GetAll()
        {
            IList<ChitGroupModel> lst = new List<ChitGroupModel>();
            foreach(ChitGroupTable chitGroupTable in _unitOfWork.GetRepository<ChitGroupTable>().GetList().Items)
            {
                lst.Add(new ChitGroupModel { GroupName = chitGroupTable.GroupName, Amount = chitGroupTable.Amount });
            }

            return lst;
        }
    }
}
