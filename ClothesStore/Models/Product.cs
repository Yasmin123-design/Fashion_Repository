using System.ComponentModel.DataAnnotations;

namespace ClothesStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public decimal Price { get; set; }
        public string Size { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public bool IsPreferred { get; set; }
        public Category Category { get; set; }
    }
}
