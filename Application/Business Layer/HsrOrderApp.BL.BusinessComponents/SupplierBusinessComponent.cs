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

        public IQueryable<Supplier> GetSuppliersByProductId(int id)
        {
            return rep.GetSuppliersByProductId(id);
        }
    }
}
