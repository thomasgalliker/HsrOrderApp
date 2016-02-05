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
    }
}