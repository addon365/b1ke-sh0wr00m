using System;

namespace addon365.Common.DataEntity
{
    public class BaseEntityWithLogFields : BaseEntity
    {

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime? Deleted { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? CreatedDeviceId { get; set; }
        public Guid? CompanyMasterId { get; set; }
        public Guid YearId { get; set; }
    }
}
