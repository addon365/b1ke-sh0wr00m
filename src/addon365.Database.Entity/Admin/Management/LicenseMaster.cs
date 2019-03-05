using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Database.Entity
{
    public class LicenseMaster:BaseEntityWithLogFields
    {
       
        public string BusinessName { get; set; }
        public Guid LicenseId { get; set; }
        public string URL { get; set; }
        public string Location { get; set; }
        public Guid CustomerId { get; set; }
        public Guid CatalogItemId { get; set; }
        public Guid VoucherId { get; set; }
        //public Dictionary<string, string> CatalogFeatures { get; set; }
        //public Dictionary<string, string> AdditionalAttributes { get; set; } 

    }
}
