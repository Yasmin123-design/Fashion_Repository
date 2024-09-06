using ClothesStore.Models;
using ClothesStore.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ClothesStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _repo;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger , IProductRepository product)
        {
            _logger = logger;
            _repo = product;
        }

        public IActionResult Index()
        {
            List<Product> products = _repo.GetPreferredProducts();
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
