using addon365.Database.Entity.Inventory.Catalog;
using addon365.Database.Service.Base;
using addon365.IService.pos;
using Threenine.Data;

namespace addon365.Database.Service.pos
{
    public class CatelogItemService : BaseService<CatalogItem>,
        ICatelogItemService
    {
        public CatelogItemService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
