using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain.Accounts
{
    public class DomainVoucherInfo
    {
    
        public AccountBook book { get; set; }
        public double Amount { get; set; }
        public bool IsCredit { get; set; }
        public string FieldInfo { get; set; }
    }
  
}
