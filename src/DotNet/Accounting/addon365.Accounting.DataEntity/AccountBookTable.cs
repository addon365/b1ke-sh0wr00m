﻿using addon365.Common.DataEntity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Accounting.DataEntity
{
    [Table("Accounting.AccountBooks")]
    public class AccountBookTable : BaseEntityWithLogFields
    {
        public string Identifier { get; set; }
        public string BookName { get; set; }
        public Guid UnderAccountGroupKeyId { get; set; }
        public AccountBookProgs ProgId { get; set; }

    }
   
    
}
