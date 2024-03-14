using System.Collections.Generic;

namespace ECommmerceSite.Models.IRepositories
{
    public interface IProductRepository
    {
        bool Create(Product product);

        bool Update(Product product);

        bool Delete(int productId);

        Product GetProductByID(int productId);

        IEnumerable<Product> GetAllProducts();
    }
}
