namespace ClothesStore.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int ProductId { get; set; }
        public int ShoppingCartId { get; set; }
        public int Amount { get; set; }
        public Product Product { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}
