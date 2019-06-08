using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using addon365.Database.Entity;
using addon365.IService.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace addon365.Web.API.Controllers
{
    public class BaseController<T> : Controller where T : BaseEntityWithLogFields
    {
        protected readonly IBaseService<T> baseService;

        public BaseController(IBaseService<T> baseService)
        {
            this.baseService = baseService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(baseService.FindAll());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public IActionResult Post(T tObj)
        {
            try
            {
                baseService.Save(tObj);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(Guid id,T tObj)
        {
            try
            {
                baseService.Update(id,tObj);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }


    }
}