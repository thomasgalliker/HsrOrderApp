using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using HsrOrderApp.BL.DomainModel;
using HsrOrderApp.DAL.Repositories;
using HsrOrderApp.DAL.Providers.EntityFramework.Repositories.Adapters;

using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

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
            var suppliers = from s in this.db.Suppliers.AsEnumerable()
                            select SupplierAdapter.AdaptSupplier(s);

            var queryable = suppliers.AsQueryable();
            return queryable;
        }

        public Supplier GetSupplierById(int supplierId)
        {
            var suppliers = from s in this.db.Suppliers.AsEnumerable()
                            where s.SupplierId == supplierId
                            select SupplierAdapter.AdaptSupplier(s);

            return suppliers.Single();
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

        public int SaveSupplier(Supplier supplier)
        {
            try
            {
                string setname = "Suppliers";
                Suppliers dbSupplier;

                bool isNew = false;
                if (supplier.SupplierId == default(int) || supplier.SupplierId <= 0)
                {
                    isNew = true;
                    dbSupplier = new Suppliers();
                }
                else
                {
                    dbSupplier = new Suppliers { SupplierId = supplier.SupplierId, /*Version = supplier.Version.ToTimestamp() */};
                    dbSupplier.EntityKey = db.CreateEntityKey(setname, dbSupplier);
                    db.AttachTo(setname, dbSupplier);
                    //db.Attach(dbSupplier);
                }
                dbSupplier.Name = supplier.Name;

                if (isNew)
                {
                    db.Suppliers.AddObject(dbSupplier);
                }
                db.SaveChanges();
                supplier.SupplierId = dbSupplier.SupplierId;
                return dbSupplier.SupplierId;
            }
            catch (OptimisticConcurrencyException ex)
            {
                if (ExceptionPolicy.HandleException(ex, "DA Policy")) throw;
                return default(int);
            }
        }

        public bool LinkSupplierToProduct(int supplierId, int prodId)
        {
            if (supplierId <= 0 || prodId <= 0) {
                return false;
            }

            try
            {
                db.SupplierConditions.AddObject(new SupplierConditions()
                {
                    SupplierId = supplierId,
                    ProductId = prodId
                });

                db.SaveChanges();

            }
            catch (Exception ex)
            {
                // General Exception handling - to be done
                return false;
            }

            return true;
        }

        #endregion
    }
}
