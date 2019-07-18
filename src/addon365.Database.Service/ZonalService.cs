using addon365.Database.Entity;
using addon365.IService;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Threenine.Data;

namespace addon365.Database.Service
{
    public class ZonalService : IZonalService
    {
        private readonly IUnitOfWork _unitOfWork;
        private const string Enabled = "Enabled";
        private const string Referer = "Referer";
        private const string Moderate = "Moderate";
        public ZonalService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<MarketingZone> GetAllActive()
        {
            var marketingZones = _unitOfWork.GetRepository<MarketingZone>().GetList().Items;

            return marketingZones;
        }
        public string Insert(MarketingZone marketingZone)
        {

            _unitOfWork.GetRepository<MarketingZone>().Add(marketingZone);
            try
            {
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return marketingZone.Identifier;
        }
        public MarketingZone GetReferer(string identifier)
        {
            var marketingZones = _unitOfWork.GetRepository<MarketingZone>().GetList().Items.Where(x => x.Identifier == identifier);
            return Mapper.Map<MarketingZone>(marketingZones);
        }
        public void Delete(MarketingZone marketingZone)
        {
            try
            {

                _unitOfWork.GetRepository<MarketingZone>().Delete(marketingZone.Id);


                _unitOfWork.SaveChanges();

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }
    }
}
