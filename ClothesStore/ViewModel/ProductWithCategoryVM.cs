using ClothesStore.Models;

namespace ClothesStore.ViewModel
{
    public class ProductWithCategoryVM
    {
        public string Category_Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
