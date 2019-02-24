using System.Collections.Generic;
using addon365.Domain.Entity.Bots;

namespace addon365.Database.Service
{
    public interface IReferrerService
    {
        IEnumerable<Referrer> GetAllActive();
        string Insert(Referrer referrer);
        Referrer GetReferer(string identifier);

    }
}