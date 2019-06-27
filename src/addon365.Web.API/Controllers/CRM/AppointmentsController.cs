using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using addon365.Database.Entity.Crm;
using addon365.IService.Crm;
using Newtonsoft.Json;
using System.IO;
using addon365.Domain.Entity.Crm;

namespace addon365.Web.API.Controllers.CRM
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : Controller
    {
        private IAppointmentService _appointmentService;
        private IAppointmentStatusService _statusService;
        public AppointmentsController(IAppointmentService _appointmentService,
            IAppointmentStatusService statusService)
        {
            this._appointmentService = _appointmentService;
            this._statusService = statusService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public IActionResult Post(AppointmentViewModel appointmentModel)
        {
            try
            {
                return Ok(_appointmentService.Save(appointmentModel));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public IActionResult Get(Guid userId)
        {
            if (userId != null && userId != Guid.Empty)
            {
                return Ok(_appointmentService.FindByUser(userId));
            }
            return Ok(_appointmentService.FindAllVM());
        }
        [HttpGet("status")]
        public IActionResult FindByStatus([FromQuery] Guid userId,
            [FromQuery] Guid statusId)
        {
            return Ok(_appointmentService.FindByStatus(userId, statusId));
        }
        [HttpPut]
        public IActionResult Put(AppointmentViewModel appointment)
        {
            return Ok(_appointmentService.Update(appointment.Id, appointment));
        }

        [HttpGet("actual")]
        public IActionResult GetAllActual()
        {
            return Ok(_appointmentService.FindAll());
        }
            
    }
}
