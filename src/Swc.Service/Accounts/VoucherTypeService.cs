using System;
using System.Collections.Generic;
using System.Text;
using addon365.Database.Entity.Accounts;
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

        public ICollection<VoucherTypeService> Save(ICollection<VoucherTypeService> typeServices)
        {
            _unitOfWork.GetRepository<VoucherTypeService>().Add(typeServices);
            _unitOfWork.SaveChanges();
            return typeServices;

        }
    }
}
