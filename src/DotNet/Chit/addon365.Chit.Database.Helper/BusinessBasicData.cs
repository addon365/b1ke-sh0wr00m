using addon365.Accounting.DataEntity;
using addon365.Chit.DataEntity;
using addon365.Common.DataEntity.Privilage;
using addon365.Crm.DataEntity;
using System;
using System.Collections.Generic;

namespace addon365.Chit.Database.Helper
{
    public class BusinessBasicData
    {
        public List<AccountGroupTable> lstAccountGroup;
        public List<AccountBookTable> lstAccountBook;
        public List<ContactTable> lstContact;
        public List<AgentTable> lstAgent;
        public List<AccountBookFieldMapTable> lstAccountBookFieldMap;
        public List<BusinessPrivilageTable> lstBusinessPrivilage;

        public BusinessBasicData()
        {
            AccountIntitilizing();
            Feature_PrivilageIntitilizing();
        }
        private void AccountIntitilizing()
        {
            lstAccountGroup = new List<AccountGroupTable>();
            lstAccountBook = new List<AccountBookTable>();
            lstAgent = new List<AgentTable>();
            lstContact = new List<ContactTable>();
            lstAccountBookFieldMap = new List<AccountBookFieldMapTable>();

            var UnderGroupAsset = new AccountGroupTable { AccountGroupName = "Assets", ProgId = AccountGroupProgs.Assets };
            var UnderGroupLiabilities = new AccountGroupTable { AccountGroupName = "Liabilities", ProgId = AccountGroupProgs.Liabilities };
            var UnderGroupIncome = new AccountGroupTable { AccountGroupName = "Income", ProgId = AccountGroupProgs.Income };
            var UnderGroupExpense = new AccountGroupTable { AccountGroupName = "Expense", ProgId = AccountGroupProgs.Expense };
            var CashInHand = new AccountGroupTable { AccountGroupName = "Cash In Hand", ParentGroupId = UnderGroupAsset.KeyId };
            var CurrentLiabilities = new AccountGroupTable { AccountGroupName = "Current Liabilities", ParentGroupId = UnderGroupLiabilities.KeyId };



            lstAccountGroup.Add(UnderGroupAsset);
            lstAccountGroup.Add(UnderGroupLiabilities);
            lstAccountGroup.Add(UnderGroupIncome);
            lstAccountGroup.Add(UnderGroupExpense);
            lstAccountGroup.Add(CashInHand);
            lstAccountGroup.Add(CurrentLiabilities);

            lstAccountGroup.Add(new AccountGroupTable { AccountGroupName = "Bank Account", ParentGroupId = UnderGroupAsset.KeyId });
            lstAccountGroup.Add(new AccountGroupTable { AccountGroupName = "Loan & Advance(Assets)", ParentGroupId = UnderGroupAsset.KeyId });
            lstAccountGroup.Add(new AccountGroupTable { AccountGroupName = "Inventments", ParentGroupId = UnderGroupAsset.KeyId });
            lstAccountGroup.Add(new AccountGroupTable { AccountGroupName = "Fixed Assets", ParentGroupId = UnderGroupAsset.KeyId });
            lstAccountGroup.Add(new AccountGroupTable { AccountGroupName = "Suspense A/c", ParentGroupId = UnderGroupAsset.KeyId });
            lstAccountGroup.Add(new AccountGroupTable { AccountGroupName = "Unsecured Loans", ParentGroupId = UnderGroupAsset.KeyId });
            lstAccountGroup.Add(new AccountGroupTable { AccountGroupName = "Miscellineous Expenses(Assets)", ParentGroupId = UnderGroupAsset.KeyId });
            lstAccountGroup.Add(new AccountGroupTable { AccountGroupName = "Current Assets", ParentGroupId = UnderGroupAsset.KeyId });
            lstAccountGroup.Add(new AccountGroupTable { AccountGroupName = "Deposits(Assets)", ParentGroupId = UnderGroupAsset.KeyId });
            lstAccountGroup.Add(new AccountGroupTable { AccountGroupName = "Bank OCC", ParentGroupId = UnderGroupLiabilities.KeyId });
            lstAccountGroup.Add(new AccountGroupTable { AccountGroupName = "Loan(Liability)", ParentGroupId = UnderGroupLiabilities.KeyId });
            lstAccountGroup.Add(new AccountGroupTable { AccountGroupName = "Duties & Taxes", ParentGroupId = UnderGroupLiabilities.KeyId });
            lstAccountGroup.Add(new AccountGroupTable { AccountGroupName = "Sundry Creditors", ParentGroupId = UnderGroupLiabilities.KeyId });
            lstAccountGroup.Add(new AccountGroupTable { AccountGroupName = "Sundry Debitors", ParentGroupId = UnderGroupLiabilities.KeyId });
            lstAccountGroup.Add(new AccountGroupTable { AccountGroupName = "Provisions", ParentGroupId = UnderGroupLiabilities.KeyId });
            lstAccountGroup.Add(new AccountGroupTable { AccountGroupName = "Capital Account", ParentGroupId = UnderGroupLiabilities.KeyId });
            lstAccountGroup.Add(new AccountGroupTable { AccountGroupName = "Branch / Divisions", ParentGroupId = UnderGroupLiabilities.KeyId });
            lstAccountGroup.Add(new AccountGroupTable { AccountGroupName = "Direct Incomes", ParentGroupId = UnderGroupIncome.KeyId });
            lstAccountGroup.Add(new AccountGroupTable { AccountGroupName = "InDirect Incomes", ParentGroupId = UnderGroupIncome.KeyId });
            lstAccountGroup.Add(new AccountGroupTable { AccountGroupName = "Provisions", ParentGroupId = UnderGroupIncome.KeyId });
            lstAccountGroup.Add(new AccountGroupTable { AccountGroupName = "Reserves & Surplus", ParentGroupId = UnderGroupIncome.KeyId });
            lstAccountGroup.Add(new AccountGroupTable { AccountGroupName = "SalesAccount", ParentGroupId = UnderGroupIncome.KeyId });
            lstAccountGroup.Add(new AccountGroupTable { AccountGroupName = "Direct Expenses", ParentGroupId = UnderGroupExpense.KeyId });
            lstAccountGroup.Add(new AccountGroupTable { AccountGroupName = "Indirect Expenses", ParentGroupId = UnderGroupExpense.KeyId });
            lstAccountGroup.Add(new AccountGroupTable { AccountGroupName = "Purchase Accounting", ParentGroupId = UnderGroupExpense.KeyId });
            lstAccountGroup.Add(new AccountGroupTable { AccountGroupName = "Ratained Earnings", ParentGroupId = UnderGroupExpense.KeyId });


            var CashBook = new AccountBookTable { KeyId = Guid.NewGuid(), BookName = "Cash", UnderAccountGroupKeyId = CashInHand.KeyId, ProgId = AccountBookProgs.CashBook };
            lstAccountBook.Add(CashBook);
            var ChitCollection = new AccountBookTable { KeyId = Guid.NewGuid(), BookName = "Chit Collection", UnderAccountGroupKeyId = CurrentLiabilities.KeyId };
            lstAccountBook.Add(ChitCollection);

            var DueAmountInfoKeyIdMap = new AccountBookFieldMapTable { FieldNameKey = "addon365.Chit.DataEntity.ChitSubscriberDueTable.DueAmountInfoKeyId", AccountBookKeyId = ChitCollection.KeyId };
            lstAccountBookFieldMap.Add(DueAmountInfoKeyIdMap);

            var AgentContactNone = new ContactTable { FirstName = "None" };
            lstContact.Add(AgentContactNone);

            var AgentNoneRow = new AgentTable { AccessId = "0", ContactId = AgentContactNone.KeyId };
            lstAgent.Add(AgentNoneRow);
        }
        private void Feature_PrivilageIntitilizing()
        {
            lstBusinessPrivilage = new List<BusinessPrivilageTable>();

            lstBusinessPrivilage.Add(new BusinessPrivilageTable { Source = "addon365.Chit.DomainEntity.Feature", PropertyName = "Agent",CurrentValue="false", DefaultValue = "false", ValueOptions ="true,false" });
            
        }
    }
}
