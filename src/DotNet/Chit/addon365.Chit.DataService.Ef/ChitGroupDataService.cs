using addon365.Chit.Database.EfContext;
using addon365.Chit.DataEntity;
using addon365.Chit.DomainEntity;
using System;
using Threenine.Data;

namespace addon365.Chit.DataService.Ef
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

        public ChitGroupModel Get(Guid keyId)
        {
            ChitGroupTable chitGroupTable;

            chitGroupTable = _unitOfWork.GetRepository<ChitGroupTable>().Single(x => x.KeyId == keyId);
            if (chitGroupTable != null)
            {

                return ConvertTo(chitGroupTable);


            }
            return null;
        }
        public ChitGroupModel Get(string accessId)
        {
            ChitGroupTable chitGroupTable;

            chitGroupTable = _unitOfWork.GetRepository<ChitGroupTable>().Single(x => x.AccessId == accessId);
            if (chitGroupTable != null)
            {
                return ConvertTo(chitGroupTable);
            }
            return null;
        }
        private ChitGroupModel ConvertTo(ChitGroupTable chitGroupTable)
        {
            return new ChitGroupModel
            {
                KeyId = chitGroupTable.KeyId,
                AccessId = chitGroupTable.AccessId,
                GroupName = chitGroupTable.GroupName,
                ChitDueAmount = chitGroupTable.ChitDueAmount,
                TotalDues = chitGroupTable.TotalDues

            };
        }


        public void GetAll()
        {
            throw new NotImplementedException();
        }

        public ChitGroupMasterModel GetMasterData()
        {
            
            ChitGroupMasterModel m = new ChitGroupMasterModel();
           

            return m;
        }

        public void Insert(ChitGroupModel chitGroupModel)
        {
            var record = _unitOfWork.GetRepository<ChitGroupTable>().Single(predicate:m => m.AccessId==chitGroupModel.AccessId);
            if (record != null)
                throw new Exception("Id already used, Please try new Id");

            _unitOfWork.GetRepository<ChitGroupTable>().Add(new ChitGroupTable { KeyId = Guid.NewGuid(),AccessId=chitGroupModel.AccessId.ToUpper(), GroupName = chitGroupModel.GroupName, ChitDueAmount = chitGroupModel.ChitDueAmount,TotalDues=chitGroupModel.TotalDues,StartDate=chitGroupModel.StartDate });
            _unitOfWork.SaveChanges();
        }

        public void Update(ChitGroupModel domainModel)
        {
            var chitGroupTable = _unitOfWork.GetRepository<ChitGroupTable>().Single(x => x.KeyId == domainModel.KeyId);

            chitGroupTable.AccessId = domainModel.AccessId;
            chitGroupTable.GroupName = domainModel.GroupName;
            chitGroupTable.TotalDues = domainModel.TotalDues;
            chitGroupTable.ChitDueAmount = domainModel.ChitDueAmount;

            _unitOfWork.GetRepository<ChitGroupTable>().Update(chitGroupTable);
        }
    }
}
