using addon365.Chit.DataEntity;
using addon365.Chit.DomainEntity;
using addon365.Chit.EfContext;
using addon365.Chit.DataHelper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threenine.Data;
using Threenine.Data.Paging;
using addon365.Common.DataHelper;
using addon365.Common.EfDataHelper;

namespace addon365.Chit.EfDataService
{
    public class ChitGroupListDataService: IChitGroupListDataService
    {
        private readonly DatabaseContext _context;
        public ChitGroupListDataService(DatabaseContext context)
        {
            MyMapper.Initialize();
            this._context = context;
        }

        public void Delete(Guid KeyId)
        {
            _context.ChitGroups.Remove(_context.ChitGroups.Find(KeyId));
            _context.SaveChanges();
        }

        public void Edit(Guid KeyId)
        {
            throw new NotImplementedException();
        }

        public PaginatedList<ChitGroupModel> Get(int PageIndex, int PageSize)
        {
            var data = _context.ChitGroups.ProjectTo<ChitGroupModel>(MyMapper.config).OrderBy(x => x.AccessId.Substring(0, 1)).ThenBy(x => Convert.ToInt64(x.AccessId.Substring(1, x.AccessId.Length)));
            var paged = PagingHelper<ChitGroupModel>.Create(data, PageIndex, PageSize);
            return paged;
        }

        public PaginatedList<ChitGroupModel> GetAll()
        {
            return Get(1, 5000);
        }

     
    }
}
