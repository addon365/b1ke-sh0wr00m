﻿using addon365.Database.Entity.Accounts;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Database.Entity.Chit
{
    public class ChitSubriberDue : BaseEntityWithLogFields
    {
        public Guid ChitSubscriberId { get; set; }
        [ForeignKey("ChitSubscriberId")]
        public virtual ChitSubscriber ChitSubscriber { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string DueNo { get; set; }
        public Voucher Voucher { get; set; }
    }
}
