using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Api.Database.Entity.Enquiries;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Enquiries
{
    public class Enquiries
    {
        public string Identifier { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string Place { get; set; }
        //public int EnquiryTypeId { get; set; }


        public void CustomMap(IMapperConfigurationExpression configuration)
        {
            //configuration.CreateMap<Enquiry, Enquiries> ()
            //    .ForMember(dest => dest.Identifier, opt => opt.MapFrom(src => src.Identifier))
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            //    .ForMember(dest => dest.MobileNumber, opt => opt.MapFrom(src => src.MobileNumber))
            //    .ForMember(dest => dest.Place, opt => opt.MapFrom(src => src.Place))
           
            //    .ReverseMap();
        }
    }
}
