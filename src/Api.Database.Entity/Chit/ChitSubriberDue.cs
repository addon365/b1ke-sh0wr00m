﻿using Api.Database.Entity.Accounts;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Database.Entity.Chit
{
    public class ChitSubriberDue : BaseEntity
    {
        public Guid ChitSubscriberId { get; set; }
        [ForeignKey("ChitSubscriberId")]
        public virtual ChitSubscriber ChitSubscriber { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string DueNo { get; set; }
        public VoucherInfo VoucherInfo { get; set; }
    }
}
