using addon365.Database.Entity.Threats;
using AutoMapper;
using System.ComponentModel.DataAnnotations;
using Threenine.Map;

namespace addon365.Domain.Entity.Bots
{
    public class AddRefererer : ICustomMap
    {
        [Required]
        [StringLength(255)]
        public string Referer { get; set; }

        public void CustomMap(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<AddRefererer, Threat>()

                .ForMember(dest => dest.Referer, opt => opt.MapFrom(src => src.Referer));
        }
    }
}
