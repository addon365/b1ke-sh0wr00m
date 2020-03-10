using addon365.Common.DataEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace addon365.Accounts.DataEntity
{
    [Table("Accounts.AccountGroups")]
    public class AccountGroupTable : BaseEntity
    {
        public string AccountGroupName { get; set; }
        public Guid? ParentGroupId { get; set; }
        public AccountGroupProgs ProgId { get; set; }
    }
    public enum AccountGroupProgs { Default,Assets,Liabilities,Income,Expense}
}
