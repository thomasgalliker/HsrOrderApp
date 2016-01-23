using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HsrOrderApp.BL.DomainModel;
using HsrOrderApp.DAL.Repositories;
using HsrOrderApp.DAL.Providers.EntityFramework.Repositories.Adapters;

namespace HsrOrderApp.DAL.Providers.EntityFramework.Repositories
{
    public class SupplierRepository : RepositoryBase, ISupplierRepository
    {
        public SupplierRepository(HsrOrderAppEntities db)
            : base(db)
        {
        }

        public SupplierRepository(string connectionString) : base(connectionString)
        {
        }

        public SupplierRepository() : base()
        {
        }

        #region Supplier

        public Supplier GetSupplierBySupplierId(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Supplier> GetAllSuppliers()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Supplier> GetSuppliersByProductId(int id)
        {
            var suppliers = from sc in this.db.SupplierConditions.AsEnumerable()
                            where sc.ProductId == id
                            join s in this.db.Suppliers on sc.SupplierId equals s.SupplierId
                            select SupplierAdapter.AdaptSupplier(s);

            return suppliers.AsQueryable();
        }

        public IQueryable<SupplierCondition> GetSupplierConditionsByProductId(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SupplierCondition> GetSupplierConditionsBySupplier(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SupplierCondition> GetAllSupplierConditions()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
