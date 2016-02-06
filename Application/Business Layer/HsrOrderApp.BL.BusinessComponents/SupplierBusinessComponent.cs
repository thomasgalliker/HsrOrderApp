using HsrOrderApp.BL.DomainModel;
using HsrOrderApp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HsrOrderApp.BL.BusinessComponents
{
    public class SupplierBusinessComponent
    {
        private ISupplierRepository rep;

        public SupplierBusinessComponent()
        {
        }

        public SupplierBusinessComponent(ISupplierRepository unitOfWork)
        {
            this.rep = unitOfWork;
        }

        public IQueryable<Supplier> GetAllSuppliers()
        {
            return this.rep.GetAllSuppliers();
        }

        public Supplier GetSupplierById(int supplierId)
        {
            return this.rep.GetSupplierById(supplierId);
        }

        public IQueryable<Supplier> GetSuppliersByProductId(int id)
        {
            return this.rep.GetSuppliersByProductId(id);
        }

        public int StoreSupplier(Supplier supplier)
        {
            return this.rep.SaveSupplier(supplier);
        }

        public bool LinkSupplierToProduct(int supplierId, int prodId)
        {
            return this.rep.LinkSupplierToProduct(supplierId, prodId);
        }

        public bool CreateNewSupplierWithLinkToProductById(int prodId, string supplierName) {
            int supplierId = this.rep.SaveSupplier(new Supplier()
            {
                Name = supplierName
            });
            return this.rep.LinkSupplierToProduct(supplierId, prodId);
        }
    }
}