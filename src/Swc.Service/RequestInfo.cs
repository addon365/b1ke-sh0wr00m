using addon365.Database.Entity;
using System;
using System.Linq;
using Threenine.Data;

namespace addon365.Database.Service
{
   public class RequestInfo
    {
        public string UserId { get; set; }
        public string DeviceId { get; set; }
        public string DeviceCode { get; set; }
        public string BranchId { get; set; }

        private int? CreatedUserId { get; set; }
        private int? CreatedDeviceId { get; set; }
        private Guid? BranchMasterId { get; set; }
        private IUnitOfWork _unitOfWork;

        public RequestInfo(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Init(string UserId)
        {
            DeviceId = "";
            var obj = _unitOfWork.GetRepository<DeviceMaster>().GetList(predicate: x => x.DeviceId == DeviceCode);
            DeviceMaster dm = null;
            if(obj!=null)
                dm=obj.Items.FirstOrDefault();

            if(dm==null)
            {
                var RequestToAuthorise=new DeviceMaster() { DeviceName = "UnKnown", DeviceId = DeviceCode,RequestedUser=UserId };

                _unitOfWork.GetRepository<DeviceMaster>().Add(RequestToAuthorise);
                _unitOfWork.SaveChanges();
                return;
            }

            if (dm.AuthorisedUser == null || dm.AuthorisedUser == "")
                return;

            DeviceId = dm.OtherId.ToString();

        }
        public void InitilizeBaseEntityInfo(BaseEntityWithLogFields baseEntity)
        {
            if (CreatedUserId == null)
                CreatedUserId = UInt16.Parse(UserId);

            if (CreatedDeviceId == null)
                CreatedDeviceId = UInt16.Parse(DeviceId);

            if (BranchMasterId == null)
                BranchMasterId = Guid.Parse(BranchId);

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
