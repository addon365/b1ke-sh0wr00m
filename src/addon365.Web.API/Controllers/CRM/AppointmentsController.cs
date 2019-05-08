using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using addon365.Database.Entity.Crm;
using addon365.IService.Crm;

namespace addon365.Web.API.Controllers.CRM
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : Controller
    {
        private IAppointmentService _appointmentService;
        public AppointmentsController(IAppointmentService _appointmentService)
        {
            this._appointmentService = _appointmentService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public IActionResult Post(Appointment appointment)
        {
            try
            {
                _appointmentService.Save(appointment);
                return Ok();
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
        public IActionResult Get(Guid statusId, bool except = false)
        {
            if (statusId != null && statusId != Guid.Empty)
            {
                return Ok(_appointmentService.FindByStatus(statusId, except));
            }
            return Ok(_appointmentService.FindAll());
        }

        [HttpPost("/addStatus")]
        public IActionResult PostApointmentStatus(AppointmentStatus appointmentStatus)
        {
            _appointmentService.UpdateStatus(appointmentStatus);
            return Ok();
        }

    }
}
