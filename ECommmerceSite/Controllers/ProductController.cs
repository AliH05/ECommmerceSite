using ECommmerceSite.Models;
using ECommmerceSite.Models.Identity;
using ECommmerceSite.Models.ViewModels;
using ECommmerceSite.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ECommmerceSite.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        private readonly UserService _userService;
        private readonly AppUser _currentUser;
        public ProductController(ProductService productService, UserService userService)
        {
            _productService = productService;
            _userService = userService;
            _currentUser = userService.GetCurrentUser();
        }

        public IActionResult Index()
        {
            var Products = _productService.GetAllProducts();
            return View(Products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var productVM = new ProductCreateViewModel();
            productVM.Categories = _productService.GetAllCategories().ToList();
            return View(productVM);
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {

            product.UserID = _currentUser.Id;
            product.CompanyID = _currentUser.CompanyId;
            var createdProduct = _productService.Create(product);
            if (createdProduct)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public IActionResult Update(int productId)
        {
            var product = _productService.GetProductByID(productId);
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            var createdProduct = _productService.Update(product);
            if (createdProduct)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int productId)
        {
            var deletedProduct = _productService.Delete(productId);
            return RedirectToAction("Index");
        }
    }
}
