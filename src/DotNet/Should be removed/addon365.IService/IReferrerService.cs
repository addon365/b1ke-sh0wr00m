using addon365.Domain.Entity.Bots;
using System.Collections.Generic;

namespace addon365.IService
{
    public interface IReferrerService
    {
        IEnumerable<Referrer> GetAllActive();
        string Insert(Referrer referrer);
        Referrer GetReferer(string identifier);

    }
}