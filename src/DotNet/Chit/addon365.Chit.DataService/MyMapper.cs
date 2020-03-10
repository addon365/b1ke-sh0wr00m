using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace addon365.Chit.EfDataService
{
    public static class MyMapper
    {
        private static bool _isInitialized;
        public static MapperConfiguration config
        { get; set; }
         
        public static void Initialize()
        {
            if (!_isInitialized)
            {
               config=new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<addon365.Chit.DataEntity.ChitGroupTable, addon365.Chit.DomainEntity.ChitGroupModel>();
                });
                _isInitialized = true;
            }
        }
    }
}
