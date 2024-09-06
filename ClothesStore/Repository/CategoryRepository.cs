using ClothesStore.Models;
using ClothesStore.Repository;

namespace ClothesStore.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ClothesContext _context;
        public CategoryRepository(ClothesContext context)
        {
            _context = context;
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }
    }
}
