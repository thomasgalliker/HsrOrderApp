using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Text;

namespace HsrOrderApp.DAL.Providers.EntityFramework.Repositories.Adapters
{
    public class SupplierAdapter
    {
        internal static BL.DomainModel.SupplierCondition AdaptSupplierCondition(EntityReference<SupplierConditions> s)
        {
            if (s.Value == null)
                return null;
            return AdaptSupplierCondition(s.Value);
        }

        internal static IQueryable<BL.DomainModel.SupplierCondition> AdaptSupplierConditions(EntityCollection<SupplierConditions> supplierConditionCollection)
        {
            if (supplierConditionCollection.IsLoaded == false)
                return null;

            var supplierConditions = from s in supplierConditionCollection.AsEnumerable()
                        select AdaptSupplierCondition(s);
            return supplierConditions.AsQueryable();
        }

        internal static BL.DomainModel.SupplierCondition AdaptSupplierCondition(SupplierConditions r)
        {
            BL.DomainModel.SupplierCondition supplierCondition = new BL.DomainModel.SupplierCondition()
            {
                ProductId = r.ProductId,
                SupplierId = r.SupplierId
            };

            return supplierCondition;
        }

        internal static BL.DomainModel.Supplier AdaptSupplier(Suppliers s)
        {
            BL.DomainModel.Supplier supplier = new BL.DomainModel.Supplier()
            {
                Name = s.Name,
                SupplierId = s.SupplierId  
            };

            return supplier;
        }
    }
}
