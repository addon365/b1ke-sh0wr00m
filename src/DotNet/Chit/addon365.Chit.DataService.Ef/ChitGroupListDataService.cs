using addon365.Chit.Context.Ef;
using addon365.Chit.DomainEntity;
using addon365.Common.DataService;
using addon365.Common.DataService.Ef;
using AutoMapper.QueryableExtensions;
using System;
using System.Linq;

namespace addon365.Chit.DataService.Ef
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
