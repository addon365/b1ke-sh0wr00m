using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Api.Database.Entity.Enquiries;
using AutoMapper;
using Threenine.Map;

namespace Api.Domain.Enquiries
{
  public  class AddEnquiries : ICustomMap
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public void CustomMap(IMapperConfigurationExpression configuration)
        {
            //configuration.CreateMap<AddEnquiries, Enquiry>()
              
            //    .ForMember(dest => destName, opt => opt.MapFrom(src => src.Name));
        }
    }
}
