using ClothesStore.Migrations;
using ClothesStore.Models;
using ClothesStore.Services;

namespace ClothesStore.Repository
{
    public class OrderRepository : IOrderRepository
    {
        ClothesContext _context;
        ShoppingCartService _ShoppingCartService;
        public OrderRepository(ClothesContext context , ShoppingCartService shoppingCartService)
        {
            _context = context;
            _ShoppingCartService = shoppingCartService;
        }
        public void CreateOrder(Order order)
        {
            order.OrderedPlaced = DateTime.Now;
            _context.Orders.Add(order);
            var cart = _ShoppingCartService.GetCart();
            foreach(var item in cart.Items)
            {
                var orderDetail = new OrderDetail
                {
                    Id = item.Id,
                    Amount = item.Amount,
                    OrderId = order.Id,
                    ProductId = item.ProductId
                };
                _context.OrderDetails.Add(orderDetail);
            }
        }

     
    }
}
