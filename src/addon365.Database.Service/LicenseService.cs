using addon365.Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Threenine.Data;

namespace addon365.Database.Service
{
    public interface ILicenseService
    {
        bool IsExists(string value);
    }

    public class LicenseService : ILicenseService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LicenseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
       
        public bool IsExists(string value)
        {
            var lst = _unitOfWork.GetRepository<LicenseMaster>()
                 .GetList().Items.Where(predicate: x => x.URL.ToLower() == value.ToLower());
            return lst.Count()>0 ;
            // your implementation
        }
    }

}
