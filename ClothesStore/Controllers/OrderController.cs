using ClothesStore.Models;
using ClothesStore.Repository;
using ClothesStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClothesStore.Controllers
{
    public class OrderController : Controller
    {
        IOrderRepository _orderRepository;
        ShoppingCartService _ShoppingCartService;
        public OrderController(IOrderRepository orderRepository , ShoppingCartService shoppingCartService)
        {
            _orderRepository = orderRepository;
            _ShoppingCartService = shoppingCartService;
        }
        [HttpGet]
        public IActionResult CheckOut()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            var cart = _ShoppingCartService.GetCart();
            if(cart.Items.Count == 0)
            {
                ModelState.AddModelError("", "your cart is empty , add some products first");
            }
            if(ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _ShoppingCartService.ClearCart();
                return RedirectToAction("CheckOutComplete");
            }
            return View(order);
        }
        public IActionResult CheckOutComplete()
        {
            ViewBag.message = "Thank You For Order! :)";
            return View();
        }
    }
}
