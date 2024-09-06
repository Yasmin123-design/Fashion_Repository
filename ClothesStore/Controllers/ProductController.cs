using ClothesStore.Models;
using ClothesStore.Repository;
using ClothesStore.Services;
using ClothesStore.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ClothesStore.Controllers
{
    public class ProductController : Controller
    {
        IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public IActionResult Index()
        {
            List<Product> products =  _productRepository.GetProducts();
            return View(products);
        }
        public IActionResult ListByCategory(string CategoryName)
        {
            ProductWithCategoryVM productWithCategoryVM;
            
            if(CategoryName == null)
            {
                productWithCategoryVM = new ProductWithCategoryVM
                {
                    Category_Name = "All Product",
                    Products = _productRepository.GetProducts()
                };                
            }
            else
            {
                productWithCategoryVM = new ProductWithCategoryVM
                {
                    Category_Name = CategoryName,
                    Products = _productRepository.GetProductsByCategory(CategoryName)
                };
            }
            return View(productWithCategoryVM);
        }
        public IActionResult PreferedProducts()
        {
            HomeVM home = new HomeVM
            {
                Products = _productRepository.GetPreferredProducts()
            };
            return View(home);
        }
    }
}
