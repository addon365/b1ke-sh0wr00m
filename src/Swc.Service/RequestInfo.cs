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
        public string DeviceCode { get; set; }
        public string BranchId { get; set; }

        private UInt16? CreatedUserId { get; set; }
        private UInt16? CreatedDeviceId { get; set; }
        private UInt16? BranchMasterId { get; set; }
        private IUnitOfWork _unitOfWork;

        public RequestInfo(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Init()
        {
            DeviceId = "";
            DeviceMaster dm = _unitOfWork.GetRepository<DeviceMaster>().GetList(predicate: x => x.DeviceId == DeviceCode).Items.FirstOrDefault();

            if(dm!=null)
                DeviceId = dm.Id.ToString();

        }
        public void InitilizeBaseEntityInfo(BaseEntity baseEntity)
        {
            if (CreatedUserId == null)
                CreatedUserId = UInt16.Parse(UserId);

            if (CreatedDeviceId == null)
                CreatedDeviceId = UInt16.Parse(DeviceId);

            if (BranchMasterId == null)
                BranchMasterId = UInt16.Parse(BranchId);

            baseEntity.Created = System.DateTime.Now;
            baseEntity.CreatedUserId = CreatedUserId;
            baseEntity.CreatedDeviceId = CreatedDeviceId;
            baseEntity.BranchMasterId = BranchMasterId;
        }
        public void ValidateMe()
        {
            if (BranchMasterId == null)
                throw new Exception("No Branch Id");

            if (CreatedDeviceId == null)
                throw new Exception("No device Id");
        }
    }
}
