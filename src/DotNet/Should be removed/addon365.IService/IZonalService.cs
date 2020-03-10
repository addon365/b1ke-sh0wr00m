using addon365.Database.Entity;
using System.Collections.Generic;

namespace addon365.IService
{
    public interface IZonalService
    {
        IEnumerable<MarketingZone> GetAllActive();
        string Insert(MarketingZone referrer);
        MarketingZone GetReferer(string identifier);
        void Delete(MarketingZone marketingZone);

    }

}
