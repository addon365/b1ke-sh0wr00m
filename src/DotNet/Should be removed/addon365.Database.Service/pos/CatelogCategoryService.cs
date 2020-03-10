using addon365.Database.Entity.Inventory.Catalog;
using addon365.Database.Service.Base;
using addon365.IService.pos;
using Threenine.Data;

namespace addon365.Database.Service.pos
{
    public class CatelogCategoryService
        : BaseService<CategoryMaster>,ICategoryService
    {
        public CatelogCategoryService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
