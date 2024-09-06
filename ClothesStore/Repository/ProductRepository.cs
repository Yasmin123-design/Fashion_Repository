using ClothesStore.Models;
using Microsoft.EntityFrameworkCore;

namespace ClothesStore.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ClothesContext _context;
        public ProductRepository(ClothesContext context)
        {
            _context = context;
        }
        public List<Product> GetPreferredProducts()
        {
            return _context.Products.Where(x => x.IsPreferred).Include(x => x.Category).ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Product> GetProducts()
        {
            return _context.Products.Include(x => x.Category).ToList();
        }

        public List<Product> GetProductsByCategory(string categoryname)
        {
            return _context.Products.Include(x => x.Category)
                .Where(x => x.Category.Name== categoryname).ToList();
            
        }
    }
}
