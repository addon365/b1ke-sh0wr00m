using System;
using System.Collections.Generic;
using System.Text;
using Api.Database.Entity.Accounts;
using Threenine.Data;

namespace Swc.Service.Accounts
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
    }
}
