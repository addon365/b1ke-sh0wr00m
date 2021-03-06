﻿using System;

namespace addon365.Database.Entity
{
    public class BaseEntityWithLogFields : BaseEntity
    {

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime? Deleted { get; set; }
        public int? CreatedUserId { get; set; }
        public int? CreatedDeviceId { get; set; }
        public Guid? BranchMasterId { get; set; }
        public Guid YearId { get; set; }
    }
}
