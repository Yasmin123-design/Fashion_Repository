using ClothesStore.Models;

namespace ClothesStore.Repository
{
    public interface IProductRepository
    {
        public List<Product> GetProducts();
        public List<Product> GetPreferredProducts();
        public Product GetProductById(int id);
        public List<Product> GetProductsByCategory(string categoryname);

    }
}
