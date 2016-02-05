#region

using System.Linq;
using System.Transactions;

using HsrOrderApp.BL.BusinessComponents.DependencyInjection;
using HsrOrderApp.BL.DomainModel;
using HsrOrderApp.DAL.Data.Repositories;
using HsrOrderApp.SharedLibraries.SharedEnums;

#endregion

namespace HsrOrderApp.BL.BusinessComponents
{
    public class ProductBusinessComponent
    {
        private readonly IProductRepository repository;

        public ProductBusinessComponent()
        {
        }

        public ProductBusinessComponent(IProductRepository unitOfWork)
        {
            this.repository = unitOfWork;
        }

        #region CRUD Operations

        public Product GetProductById(int productId)
        {
            Product product = this.repository.GetById(productId);
            return product;
        }

        public IQueryable<Product> GetProductsByCriteria(ProductSearchType searchType, string category, string productName)
        {
            IQueryable<Product> products = null;

            switch (searchType)
            {
                case ProductSearchType.None:
                    products = this.repository.GetAll();
                    break;
                case ProductSearchType.ByCategory:
                    products = this.repository.GetAll().Where(cu => cu.Category == category);
                    break;
                case ProductSearchType.ByName:
                    products = this.repository.GetAll().Where(cu => cu.Name == productName);
                    break;
            }

            return products;
        }

        public IQueryable<Product> GetProductsBySupplierId(int supplierId)
        {
            return this.repository.GetProductsBySupplierId(supplierId);
        }

        public int StoreProduct(Product product)
        {
            int productId = default(int);
            using (TransactionScope transaction = new TransactionScope())
            {
                productId = this.repository.SaveProduct(product);
                transaction.Complete();
            }

            return productId;
        }

        public void DeleteProduct(int productId)
        {
            this.repository.DeleteProduct(productId);
        }

        #endregion

        public void GetEstimatedDeliveryTime(int productId, out int unitsAvailable, out int estimatedDeliveryTimeInDays)
        {
            OrderBusinessComponent orderBC = DependencyInjectionHelper.GetOrderBusinessComponent();
            Product product = this.repository.GetById(productId);

            int unitsOrdered = orderBC.GetAllOrderDetails().Where(od => od.Product.ProductId == product.ProductId).Sum(od => od.QuantityInUnits);

            unitsAvailable = product.UnitsOnStock - unitsOrdered;
            if ((unitsAvailable) < 0)
            {
                unitsAvailable = 0;
            }

            estimatedDeliveryTimeInDays = -1;
            // Todo: Implement the logic to calculate the estimatedDelivertyTimeInDays (see SupplierCondition)
        }
    }
}