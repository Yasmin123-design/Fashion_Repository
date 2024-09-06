using ClothesStore.Models;

namespace ClothesStore.Repository
{
    public interface ICategoryRepository
    {
        public List<Category> GetCategories();
    }
}
