using addon365.Database.Entity.Crm;
using addon365.Database.Service.Util;
using addon365.Domain.Entity.Crm;
using addon365.IService;
using addon365.IService.Crm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace addon365.Web.API.Controllers.CRM
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : Controller
    {
        private IAppointmentService _appointmentService;
        private IAppointmentStatusService _statusService;
        private IUserService _userService;
        public AppointmentsController(
            IAppointmentService _appointmentService,
            IAppointmentStatusService statusService,
            IUserService userService)
        {
            this._appointmentService = _appointmentService;
            this._statusService = statusService;
            this._userService = userService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public IActionResult Post(AppointmentViewModel appointmentModel)
        {
            try
            {
                Appointment appointment = _appointmentService.Save(appointmentModel);
                if (appointmentModel.AssignedToId != null)
                {
                    Guid id = (Guid)appointmentModel.AssignedToId;
                    string token = _userService.GetToken(id);
                    string message = "New appointment has been assigned to you.";

                    NotificationService.SendNotification(token, "Appointment Assigned",
                          message,
                          data: new Dictionary<string, string>()
                          {
                            { "type","appointment" },
                            {"id",$"{appointment.Id}" }

                          }
                          );
                }


                return Ok(appointment);
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
