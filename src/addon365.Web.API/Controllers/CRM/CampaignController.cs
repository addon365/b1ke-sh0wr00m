using addon365.Database.Entity.Crm;
using addon365.IService.Base;
using addon365.IService.Crm;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace addon365.Web.API.Controllers.CRM
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : BaseController<Campaign>
    {
        ICampaignService campaignService;
        public CampaignController(ICampaignService baseService)
            : base(baseService)
        {
            campaignService = baseService;
        }

        [HttpGet("listvm")]
        public IActionResult GetCampaignViewModel()
        {
            return Ok(campaignService.GetCampaigns());
        }

        [HttpGet("infos")]
        public IActionResult GetCampaignInfos(Guid campaignId)
        {
            return Ok(campaignService.FindCampaignInfos(campaignId));
        }

        [HttpGet("info")]
        public IActionResult GetCampaignInfo(Guid campaignInfoId)
        {
            return Ok(campaignService.FindCampaignInfo(campaignInfoId));
        }

        public override IActionResult Post(IList<Campaign> tObj)
        {
            return Ok(baseService.Save(tObj));
        }

    }
}