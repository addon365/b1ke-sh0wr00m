using addon365.Database.Entity.Accounts;
using addon365.IService.Accounts;
using System.Collections.Generic;
using Threenine.Data;

namespace addon365.Database.Service.Accounts
{
    public class VoucherTypeService : IVoucherTypeService
    {
        IUnitOfWork _unitOfWork;
        public VoucherTypeService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public VoucherTypeMaster FindByName(string name)
        {
            var result = _unitOfWork.GetReadOnlyRepository<VoucherTypeMaster>()
                .GetList(
                predicate: vtm => vtm.Name.CompareTo(name) == 0)
                .Items;
            if (result.Count == 0)
                return null;
            return result[0];
        }

        public ICollection<VoucherTypeMaster> Save(ICollection<VoucherTypeMaster> typeServices)
        {
            _unitOfWork.GetRepository<VoucherTypeMaster>().Add(typeServices);
            _unitOfWork.SaveChanges();
            return typeServices;

        }
    }
}
