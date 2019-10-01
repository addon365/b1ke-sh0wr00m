
using addon365.Database.Entity.Inventory.Catalog;
using Microsoft.AspNetCore.Mvc;
using addon365.IService.pos;

namespace addon365.Web.API.Controllers.pos
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController<CategoryMaster>
    {
        public CategoryController(ICategoryService baseService) : base(baseService)
        {
        }
    }
}