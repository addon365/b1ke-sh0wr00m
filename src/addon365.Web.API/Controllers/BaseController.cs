using addon365.Database.Entity;
using addon365.IService.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
        public IActionResult Get([FromQuery]Guid id)
        {
            if (id == null || Guid.Empty == id)
                return Ok(baseService.FindAll());
            else
                return Ok(baseService.Find(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public virtual IActionResult Post(IList<T> tObj)
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

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, T tObj)
        {
            try
            {
                return Ok(baseService.Update(id, tObj));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }


    }
}