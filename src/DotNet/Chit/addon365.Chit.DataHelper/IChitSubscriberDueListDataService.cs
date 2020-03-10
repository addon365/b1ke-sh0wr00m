using addon365.Chit.DomainEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace addon365.Chit.DataHelper
{
    public interface IChitSubscriberDueListDataService
    {
        void Delete(Guid KeyId);
        void Edit(Guid KeyId);
        IList<ChitSubscriberDueListModel> GetAll();
    }
}
