using addon365.Database.Entity.Inventory.Catalog;
using addon365.IService.pos;
using Microsoft.AspNetCore.Mvc;

namespace addon365.Web.API.Controllers.pos
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController<CatalogBrand>
    {
        public BrandsController(ICatelogBrandService baseService) : base(baseService)
        {
        }
    }
}