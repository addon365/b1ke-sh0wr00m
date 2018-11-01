using Api.Database.Entity.Products;
using Api.Domain.Enquiries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Threenine.Data;

namespace Swc.Service
{
  public class AccessoriesService:IAccessoriesService
    {
        private readonly IUnitOfWork _unitOfWork;
       
        public AccessoriesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ExtraFittingsAccessories> GetAccessories()
        {
            var access = _unitOfWork.GetRepository<ExtraFittingsAccessories>().GetList().Items;
            return access;
        }

        public IEnumerable<ExtraFittingsAccessories> GetAccessories(Guid ProductId)
        {
            var AllProducts = _unitOfWork.GetRepository<Product>().GetList().Items;
            var access = _unitOfWork.GetRepository<ExtraFittingsAccessories>().GetList().Items.Where(x => x.ProductId == ProductId);
            foreach (ExtraFittingsAccessories efc in access)
            {
                efc.AccessoriesProductItem = AllProducts.Where(y => y.Id == efc.AccessoriesProductId).First();
            }
            return access;
        }

        public string InsertAccessories(IEnumerable<ExtraFittingsAccessories> extrafittings)
        {
            try
            {
                foreach(ExtraFittingsAccessories ef in extrafittings)
                {
                    ef.Product = null;
                    ef.AccessoriesProductItem = null;
                }
                _unitOfWork.GetRepository<ExtraFittingsAccessories>().Add(extrafittings);
                _unitOfWork.SaveChanges();
            }
            catch(Exception ex)
            {
                string str = ex.Message;
            }
            return null;
        }

        public string UpdateAccessories(IEnumerable<ExtraFittingsAccessories> extrafittings)
        {
            try
            {
                foreach (ExtraFittingsAccessories ef in extrafittings)
                {
                    ef.Product = null;
                    ef.AccessoriesProductItem = null;
                    
                }
                

                _unitOfWork.GetRepository<ExtraFittingsAccessories>().Update(extrafittings);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            return null;
        }
        public void DeleteAccessories(Guid ProductId)
        {

            _unitOfWork.GetRepository<ExtraFittingsAccessories>().Delete(ProductId);
            
            _unitOfWork.SaveChanges();
        }
    }
}
