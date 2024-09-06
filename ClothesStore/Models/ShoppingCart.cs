using ClothesStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClothesStore.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();
        public void AddItem(Product product)
        {
            var cartitem = Items.Where(x => x.ProductId == product.Id).FirstOrDefault();
            if(cartitem == null)
            {
                ShoppingCartItem item = new ShoppingCartItem
                {
                    Id = product.Id,
                    ProductId = product.Id,
                    ItemName = product.Name,
                    Amount = 1,
                    ShoppingCartId = Id
                    
                };
                Items.Add(item);
            }
            else
            {
                cartitem.Amount += 1;
            }
        }
        public void RemoveItem(Product product)
        {
            var cartitem = Items.Where(x => x.ProductId == product.Id).FirstOrDefault();
            if (cartitem != null)
            {
                if(cartitem.Amount > 1)
                {
                    cartitem.Amount -= 1;

                }
                else
                {
                    Items.Remove(cartitem);
                }
            }
        }

    }
}
