using ECommmerceSite.Models;
using ECommmerceSite.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;

namespace ECommmerceSite.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public bool Create(Product product)
        {
            bool createdProduct = _productRepository.Create(product);
            return createdProduct;
        }

        public bool Delete(int productId)
        {
            bool deletedProduct = _productRepository.Delete(productId);
            return deletedProduct;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var gottenProducts = _productRepository.GetAllProducts();
            return gottenProducts;
        }

        public Product GetProductByID(int productId)
        {
            var productById = _productRepository.GetProductByID(productId);
            return productById;
        }

        public bool Update(Product product)
        {
            bool updatedProduct = _productRepository.Update(product);
            return updatedProduct;
        }
        public IEnumerable<Category> GetAllCategories() 
        {
            var gottenCategories = _productRepository.GetAllCategories();
            return gottenCategories;
        }
    }
}
