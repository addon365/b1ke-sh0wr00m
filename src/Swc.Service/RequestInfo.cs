using Api.Database.Entity;
using System;
using System.Linq;
using Threenine.Data;

namespace Swc.Service
{
   public class RequestInfo
    {
        public string UserId { get; set; }
        public string DeviceId { get; set; }
        public string BranchId { get; set; }

        private UInt16? CreatedUserId { get; set; }
        private UInt16? CreatedDeviceId { get; set; }
        private UInt16? BranchMasterId { get; set; }
        private IUnitOfWork _unitOfWork;

        public RequestInfo(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void InitilizeBaseEntityInfo(BaseEntity baseEntity)
        {
            if (CreatedUserId == null)
                CreatedUserId = UInt16.Parse(UserId);

            if (CreatedDeviceId == null)
                CreatedDeviceId = _unitOfWork.GetRepository<DeviceMaster>().GetList(predicate: x => x.DeviceId == DeviceId).Items.FirstOrDefault().Id;

            if (BranchMasterId == null)
                BranchMasterId = _unitOfWork.GetRepository<LicenseMaster>().GetList(predicate: x => x.LicenseId == BranchId).Items.FirstOrDefault().Id;

            baseEntity.Created = System.DateTime.Now;
            baseEntity.CreatedUserId = CreatedUserId;
            baseEntity.CreatedDeviceId = CreatedDeviceId;
            baseEntity.BranchMasterId = BranchMasterId;
        }
    }
}
