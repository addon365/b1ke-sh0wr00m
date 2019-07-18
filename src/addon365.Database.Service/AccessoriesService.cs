using addon365.Database.Entity.Inventory.Catalog;
using addon365.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using Threenine.Data;

namespace addon365.Database.Service
{
    public class AccessoriesService : IAccessoriesService
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

        public IEnumerable<ExtraFittingsAccessories> GetAccessories(Guid CatalogItemId)
        {
            var AllProducts = _unitOfWork.GetRepository<CatalogItem>().GetList().Items;
            var access = _unitOfWork.GetRepository<ExtraFittingsAccessories>().GetList().Items.Where(x => x.CatalogItemId == CatalogItemId);
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
                foreach (ExtraFittingsAccessories ef in extrafittings)
                {
                    ef.CatalogItem = null;
                    ef.AccessoriesProductItem = null;
                }
                _unitOfWork.GetRepository<ExtraFittingsAccessories>().Add(extrafittings);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
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
                    ef.CatalogItem = null;
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
