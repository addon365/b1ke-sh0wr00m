using addon365.Chit.DomainEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace addon365.Chit.IDataService
{
    public interface IChitGroupListDataService
    {
        void Delete(Guid KeyId);
        void Edit(Guid KeyId);
        IList<ChitGroupModel> GetAll();
    }
}
