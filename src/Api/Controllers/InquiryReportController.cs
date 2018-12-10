using System;
using System.Collections.Generic;
using Api.Database.Entity.Report;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swc.Service.Report;
using swcApi.Utils;

namespace swcApi.Controllers
{
    /// <summary>
    /// Provides REST API for dashboard for Angular Client App.
    /// </summary>
    [Produces("application/json")]
    [Route("api/{license:license}/v{version:apiVersion}/[controller]")]
    public class InquiryReportController : Controller
    {
        private readonly AppSettings _appSettings;
        private readonly ILogger _logger;
        private readonly IInquiryReportService _inquiryReportService;

        /// <summary>
        /// Injecting required instances
        /// </summary>
        /// <param name="inquiryReportService"></param>
        /// <param name="appSettings"></param>
        /// <param name="logger"></param>
        public InquiryReportController(IInquiryReportService inquiryReportService,
            IOptions<AppSettings> appSettings,
            ILogger<UserController> logger)
        {
            this._appSettings = appSettings.Value;
            this._inquiryReportService = inquiryReportService;
            this._logger = logger;
        }

        [HttpGet]
        public IActionResult Get([FromQuery(Name = "reportType")] ReportType type)
        {
            var result=_inquiryReportService.GetReport(type);
            return Ok(result);
        }
    }
}