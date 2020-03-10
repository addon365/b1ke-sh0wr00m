using addon365.Chit.DomainEntity;
using addon365.Common.DataService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace addon365.Chit.DataService
{
    public interface IChitGroupListDataService
    {
        void Delete(Guid KeyId);
        void Edit(Guid KeyId);
        PaginatedList<ChitGroupModel> GetAll();
        PaginatedList<ChitGroupModel> Get(int StartIndex, int EndIndex);
    }
}
