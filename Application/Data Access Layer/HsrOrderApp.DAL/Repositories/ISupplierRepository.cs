using HsrOrderApp.BL.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HsrOrderApp.DAL.Repositories
{
    public interface ISupplierRepository
    {
        Supplier GetSupplierBySupplierId(int id);
        IQueryable<Supplier> GetAllSuppliers();
        Supplier GetSupplierById(int supplierId);
        IQueryable<Supplier> GetSuppliersByProductId(int id);

        IQueryable<SupplierCondition> GetSupplierConditionsByProductId(int id);
        IQueryable<SupplierCondition> GetSupplierConditionsBySupplier(int id);
        IQueryable<SupplierCondition> GetAllSupplierConditions();
    }
}
