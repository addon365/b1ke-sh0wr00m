using Api.Database.Entity.Enquiries;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Threenine.Data;

namespace Swc.Service
{
    public class EnquiryTypeService:IEnquiryTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private const string Enabled = "Enabled";
        private const string Referer = "Referer";
        private const string Moderate = "Moderate";
        public EnquiryTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<EnquiryType> GetAllEnquiryType()
        {
            var enquiryTypes = _unitOfWork.GetRepository<EnquiryType>().GetList().Items;

            return enquiryTypes;
        }
        public int Insert(EnquiryType enquiryType)
        {

            _unitOfWork.GetRepository<EnquiryType>().Add(enquiryType);
            try
            {
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return enquiryType.ProgrammerId;
        }
        public EnquiryType GetEnquiryType(int programmerId)
        {
            var enquiryTypes = _unitOfWork.GetRepository<EnquiryType>().GetList().Items.Where(x => x.ProgrammerId == programmerId);
            return Mapper.Map<EnquiryType>(enquiryTypes);
        }
        public void Delete(EnquiryType enquiryType)
        {
            try
            {

                _unitOfWork.GetRepository<EnquiryType>().Delete(enquiryType.Id);


                _unitOfWork.SaveChanges();

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }
    }
}
