using ECommmerceSite.Data;
using ECommmerceSite.Models.IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace ECommmerceSite.Models.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Create(Product Product)
        {
            try
            {
                _context.Products.Add(Product);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool Delete(int productId)
        {
            try
            {
                Product product = GetProductByID(productId);
                _context.Products.Remove(product);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var products = _context.Products.ToList();
            return products;
        }

        public Product GetProductByID(int productId)
        {
            Product Product = _context.Products.SingleOrDefault(x => x.ID == productId);
            return Product;
        }

        public bool Update(Product product)
        {
            try
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }
    }
}

//https://upload.wikimedia.org/wikipedia/commons/thumb/a/ad/IPhone_1st_Gen.svg/1200px-IPhone_1st_Gen.svg.png