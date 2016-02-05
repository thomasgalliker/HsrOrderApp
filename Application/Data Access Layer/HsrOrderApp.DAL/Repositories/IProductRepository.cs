#region

using System.Linq;
using HsrOrderApp.BL.DomainModel;

#endregion

namespace HsrOrderApp.DAL.Data.Repositories
{
    public interface IProductRepository
    {
        IQueryable<Product> GetAll();

        IQueryable<Product> GetProductsBySupplierId(int supplierId);

        Product GetById(int id);

        int SaveProduct(Product product);

        void DeleteProduct(int id);
    }
}