using ClothesStore.Models;
using ClothesStore.Repository;
using ClothesStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClothesStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingCartService _shoppingCartService;
        private readonly IProductRepository _productRepository;
        public ShoppingCartController(ShoppingCartService shoppingCartService , IProductRepository productRepository)
        {
            _shoppingCartService = shoppingCartService;
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var cart = _shoppingCartService.GetCart();
            return View(cart);
        }
        public IActionResult AddToCart(int productid)
        {
            var product = _productRepository.GetProductById(productid);
            // get cart from session
            var cart = _shoppingCartService.GetCart();
            cart.AddItem(product);
            // save cart in session 
            _shoppingCartService.SaveCart(cart);
            return RedirectToAction("Index");
        }
        public IActionResult RemoveFromCart(int productid)
        {
            var cart = _shoppingCartService.GetCart();
            var product = _productRepository.GetProductById(productid);
            cart.RemoveItem(product);
            _shoppingCartService.SaveCart(cart);
            return RedirectToAction("Index");

        }
    }
}
