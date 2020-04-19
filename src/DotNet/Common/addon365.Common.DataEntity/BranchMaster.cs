using System;

namespace addon365.Common.DataEntity
{
    public class BranchMaster : BaseEntityWithLogFields
    {

        public string BranchName { get; set; }
        public string ShortCode { get; set; }
        public string Location { get; set; }
        public Guid LicenseMasterId { get; set; }

    }
}
