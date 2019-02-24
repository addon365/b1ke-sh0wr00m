using addon365.Database.Entity.Threats;
using AutoMapper;

namespace addon365.Domain.Entity.Bots
{
    public class ThreatTypeResolver : IValueResolver<Threat, Referrer, string>
    {
        public string Resolve(Threat source, Referrer destination, string destMember, ResolutionContext context)
        {
            return source.Status.Name;
        }
    }
}