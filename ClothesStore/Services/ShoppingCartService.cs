using ClothesStore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClothesStore.Services
{
    public class ShoppingCartService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ShoppingCartService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ShoppingCart GetCart()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            var cartJson = session.GetString("ShoppingCart");
            return string.IsNullOrEmpty(cartJson) ? new ShoppingCart() : JsonConvert.DeserializeObject<ShoppingCart>(cartJson);
        }

        public void SaveCart(ShoppingCart cart)
        {
            var session = _httpContextAccessor.HttpContext.Session;
            session.SetString("ShoppingCart", JsonConvert.SerializeObject(cart));
        }
        public void ClearCart()
        {
            // استرجاع العربة الحالية
            var cart = GetCart();

            // تفريغ العناصر من العربة
            cart.Items.Clear();

            // حفظ العربة المفرغة
            SaveCart(cart);

        }
    }
}
