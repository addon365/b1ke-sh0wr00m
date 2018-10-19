using Api.Database.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swc.Service
{
    public interface IZonalService
    {
        IEnumerable<MarketingZone> GetAllActive();
        string Insert(MarketingZone referrer);
        MarketingZone GetReferer(string identifier);
        void Delete(MarketingZone marketingZone);

    }
    
}
