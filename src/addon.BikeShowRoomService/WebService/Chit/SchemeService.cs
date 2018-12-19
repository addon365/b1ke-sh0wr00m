﻿using addon.BikeShowRoomService.BaseService;
using Api.Database.Entity.Chit;
using Swc.Service.Chit;
using System;
using System.Collections.Generic;
using System.Text;

namespace addon.BikeShowRoomService.WebService.Chit
{
    public class SchemeService : BaseClientService<ChitScheme>, ISchemeService
    {
        public override string getUrl()
        {
            return "Scheme";
        }
    }
}