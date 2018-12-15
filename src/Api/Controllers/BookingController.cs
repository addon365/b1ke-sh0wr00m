﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Swc.Service.Sales;
using Api.Domain.Booking;
using System;
using System.Threading.Tasks;
using Swc.Service;

namespace swcApi.Controllers
{
    /// <inheritdoc />
    [Produces("application/json")]
    [Route("api/{license:license}/v{version:apiVersion}/[controller]")]
    public class BookingController : Controller
    {
        private readonly IBookingService _BookingService;
        private RequestInfo _r;

        /// <inheritdoc />
        public BookingController(IBookingService BookingService, RequestInfo r)
        {
            _BookingService = BookingService;
            _r = r;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InsertBooking model)
        {
            try
            { 
         
                if (model == null)
                {
                    return BadRequest();
                }
                _r.UserId = Request.Headers["UserId"].ToString();
                _r.BranchId = Request.Headers["BranchId"].ToString();
                _r.DeviceId= Request.Headers["DeviceId"].ToString();
                await _BookingService.Insert(model);
                

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet]
        public String Get()
        {
            
            return "Hellow";
        }

       
      
    }
}