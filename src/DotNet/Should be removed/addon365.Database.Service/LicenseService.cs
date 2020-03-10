using addon365.Database.Entity;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IList<LicenseMaster> lst;
        public LicenseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
             lst = _unitOfWork.GetRepository<LicenseMaster>()
                .GetList().Items;
        }

        public bool IsExists(string value)
        {
            
            return lst.Where(predicate: x => x.URL.ToLower() == value.ToLower()).Count() > 0;
            // your implementation
        }
    }

}
